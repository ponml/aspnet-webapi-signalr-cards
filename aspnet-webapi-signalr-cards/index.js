import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import Card from './Scripts/Card.js';
import Deck from './Scripts/Deck.js';
import ChatWindow from './Scripts/ChatWindow.js';

class App extends React.Component {
    constructor(props) {
        super(props);
        var me = this;
        me.state = {
            deck: []
        };
        me.signalRConnection = $.connection;
        me.signalRConnection.hub.start().done(function () { });
        me.chatHub = me.signalRConnection.chatHub;
        me.init(props);
    }

    init(props) {
        var me = this;
        // Send an AJAX request
        return axios.get("api/decks?id=1").then(function (response) {
            // On success, 'data' contains a list of cards.
            var data = response.data;
            me.setState({
                deck: <Deck key={data.Id} data={data} />
            });
        });
    }

    clickCard(card) {

    }

    getCard(Id) {

    }

    componentDidMount() {
    }

    componentWillUnmount() {
    }

    render() {
        return (
            <div>
                <div className="container">
                    <ChatWindow chatHub={this.chatHub} />
                </div>
                <div>
                    <h2>Deck</h2>
                    <div id="deck">
                        { this.state.deck }
                    </div>
                </div>
            </div>
        );
    }

}

$(document).ready(function () {
    ReactDOM.render(
        <App name="Cards" />,
        document.getElementById('root')
    );
});