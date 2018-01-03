import React from 'react';
import ReactDOM from 'react-dom';
import ChatWindow from './ChatWindow.js';
import Card from './Card.js';

class Lobby extends React.Component {
    constructor(props) {
        super(props);
        var me = this;
        me.signalRConnection;
        me.lobbyHub;
        //me.name = props.match.params.name;
        var requestedLobbyName = props.match.params.name;
        if (props.signalRConnection) {
            me.signalRConnection = props.signalRConnection;
        } else {
            me.signalRConnection = $.connection;
        }

        $.connection.hub.error(function (error) {
            console.log('SignalR error: ' + error)
        });

        me.lobbyHub = me.signalRConnection.lobbyHub;

        me.signalRConnection.hub.start().done(function () {
            var lobbyCall = me.lobbyHub.server.JoinLobby(me.lobbyHub.connection.id, requestedLobbyName);
            lobbyCall.always(function (r) {
                console.log(r);
            });

            lobbyCall.done(function (response) {
                console.log("whoaaaaa: ", response);
                me.name = response.lobby.Name;
                me.setState({
                    isLoading: false,
                    cards: response.cards.map((card, index) => {
                        return (
                            <li key={index}>
                                <div className="flex">
                                    <Card data={card}></Card>
                                </div>
                            </li>
                        );
                    })
                });
            });
        });
        

        me.state = {
            isLoading: true,
            cards: []
        };
    }

    //make sure we don't just flash the loading icon
    componentDidMount() {
        //setTimeout(() =>
        //    this.setState({ isLoading: false }), 1000
        //);
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
                    <div>
                        {this.state.cards}
                    </div>
                </div>
            );
        }
    }
}

module.exports = Lobby;