import React from 'react';
import ReactDOM from 'react-dom';
import ChatWindow from './ChatWindow.js';

class Lobby extends React.Component {
    constructor(props) {
        super(props);
        var me = this;
        me.signalRConnection;
        me.lobbyHub;
        me.name = props.match.params.name;

        if (props.signalRConnection) {
            me.signalRConnection = props.signalRConnection;
        } else {
            me.signalRConnection = $.connection;
        }

        me.lobbyHub = me.signalRConnection.lobbyHub;


        me.signalRConnection.hub.start().done(function () {
            me.lobbyHub.server.joinLobby(me.lobbyHub.connection.id, me.name).done(function (lobby) {
                console.log("whoaaaaa: ", lobby);
                me.setState({
                    isLoading: false
                });
            });
        });
        

        me.state = {
            isLoading: true
        };
    }

    //make sure we don't just flash the loading icon
    componentDidMount() {
        setTimeout(() =>
            this.setState({ isLoading: false }), 1000
        );
    }

    render() {
        const me = this;
        if (me.state.isLoading) {
            return (
                <div>LOADING</div>

            );
        } else {
            return (
                <div>
                    <h1>Lobby Name {this.name}</h1>
                    <h2>Chat</h2>
                    <ChatWindow />
                </div>
            );
        }
    }
}

module.exports = Lobby;