import React from 'react';
import ReactDOM from 'react-dom';
import ChatWindow from './ChatWindow.js';

class Lobby extends React.Component {
    constructor(props) {
        super(props);
        var me = this;
        me.signalRConnection;
        me.lobbyHub;
        me.lobbyJoinName = props.match.params.name;

        if (props.signalRConnection) {
            me.signalRConnection = props.signalRConnection;
        } else {
            me.signalRConnection = $.connection;
        }

        me.lobbyHub = me.signalRConnection.lobbyHub;        

        me.state = {
            isLoading: true
        };
    }

    //make sure we don't just flash the loading icon
    componentDidMount() {
        var me = this;
        me.signalRConnection.hub.start().done(function () {
            me.lobbyHub.server.joinLobby(me.lobbyHub.connection.id, me.lobbyJoinName).done(function (lobby) {
                console.log("whoaaaaa: ", lobby);
                try {
                    var lobby = JSON.parse(lobby);
                    me.setState({
                        isLoading: false,
                        lobby: new LobbyModel(lobby)
                    });
                } catch (e) {
                    me.setState({
                        isLoading: false,
                        failedToJoinLobby: true
                    });
                }
            });
        });
    }

    render() {
        const me = this;
        const lobbyName = me.state.lobby ? me.state.lobby.name : "";
        if (me.state.isLoading) {
            return (
                <div>LOADING</div>

            );
        } else {
            return (
                <div>
                    <h1>Lobby Name {lobbyName}</h1>
                    <h2>Chat</h2>
                    <ChatWindow />
                </div>
            );
        }
    }
}

function LobbyModel(options) {
    var me = this;
    me.name = options.Name;
    me.gameId = options.GameId;
    me.id = options.Id;
    me.groupId = options.GroupId;
}

module.exports = Lobby;