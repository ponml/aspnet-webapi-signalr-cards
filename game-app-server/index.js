import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import Card from './Scripts/Card.js';
import Deck from './Scripts/Deck.js';
import ChatWindow from './Scripts/ChatWindow.js';
import { Router, Route } from 'react-router';

class App extends React.Component {
    constructor(props) {
        super(props);
        var me = this;
        me.state = {
            lobbies: []
        };
        me.init(props);
    }

    init(props) {
        var me = this;
        me.signalRConnection = $.connection;
        me.signalRConnection.hub.start().done(function () { });
        me.lobbyHub = me.signalRConnection.lobbyHub;
    }

    joinLobby(lobby) {
        me.lobbyHub.server.joinLobby(me.lobbyHub.connection.id, lobby.name);
        window.location = window.location + "/lobby/" + lobby.name;
    }

    createLobby(name) {
        joinLobby({ name: name });        
    }

    componentDidMount() {
    }

    componentWillUnmount() {
    }

    render() {

        var lobbies = this.state.lobbies.map((lobby, index) => {
            return (
                <li key={index}>
                    <div className="flex">
                        <span>{lobby.name}</span>
                        <button>JOIN</button>
                    </div>
                </li>
            )
        });

        return (
            <div>
                <div className="container">
                    <ul>
                        {lobbies}
                    </ul>
                </div>
                <div>
>
                </div>
            </div>
        );
    }

}

$(document).ready(function () {
    ReactDOM.render(
        <Router>
            <Route path="/" component={App} />
            <Route path="/lobby/:name" component={Lobby} />
        </Router>,
        document.getElementById('root')
    );
});