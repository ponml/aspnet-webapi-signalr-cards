import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import Card from './Scripts/Card.js';
import Deck from './Scripts/Deck.js';
import Lobby from './Scripts/Lobby.js';
import { BrowserRouter, HashRouter, Route, Switch } from 'react-router-dom'

class App extends React.Component {
    constructor(props) {
        super(props);
        var me = this;
        me.state = {
            lobbies: [],
            newLobbyName: ""
        };
        me.init(props);

        me.handleNewLobby = me.handleNewLobby.bind(me);
        me.handleNewLobbyChange = me.handleNewLobbyChange.bind(me);

    }

    init(props) {
        var me = this;
        me.signalRConnection = $.connection;
        me.signalRConnection.hub.start().done(function () { });
        me.lobbyHub = me.signalRConnection.lobbyHub;
    }

    joinLobby(lobby) {
        var me = this;
        me.lobbyHub.server.joinLobby(me.lobbyHub.connection.id, lobby.name);
        window.location = window.location.href + "lobby/" + lobby.name;
    }

    createLobby(name) {
        var me = this;
        me.joinLobby({ name: name });        
    }

    
    handleNewLobby(e) {
        var me = this;
        if (e.keyCode == 13) {
            me.createLobby(me.state.newLobbyName);
            me.setState({
                newLobbyName: ""
            });
        }
    }

    handleNewLobbyChange(e) {
        var me = this;
        me.setState({
            newLobbyName: e.target.value
        });
    }

    componentDidMount() {
    }

    componentWillUnmount() {
    }

    render() {

        
        var lobbies = this.state.lobbies.map((lobby, index) => {
            var join = function () { this.joinLobby(lobby.name) };
            return (
                <li key={index}>
                    <div className="flex">
                        <span>{lobby.name}</span>
                        <button onClick={join}>JOIN</button>
                    </div>
                </li>
            )
        });
        lobbies = lobbies ? lobbies : null;
        return (
            <div>
                <div className="container">
                    bwahh
                    <input type="text" placeholder={"type here"} value={this.state.newLobbyName} onKeyUp={this.handleNewLobby} onChange={this.handleNewLobbyChange} />
                    <ul>
                        {lobbies}
                    </ul>
                </div>

            </div>
        );
    }

}

$(document).ready(function () {
    ReactDOM.render(
        <HashRouter>
            <div>
            <Route exact path="/" component={App} />
            <Route exact path="/lobby/:name" component={Lobby} />
            </div>
        </HashRouter>,
        document.getElementById('root')
    );
});