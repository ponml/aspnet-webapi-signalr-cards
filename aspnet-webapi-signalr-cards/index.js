import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import Card from './Scripts/Card.js';
import ChatWindow from './Scripts/ChatWindow.js';

var uri = 'api/cards';

function formatItem(item) {
    return item.Name + ': ' + item.Value;
}

function find() {
    var id = $('#cardId').val();
    return axios.get(uri, { params: { id: id } }).then(function (response) {
        $('#card').text(formatItem(response.data));
    });
}

$(document).ready(function () {
    ReactDOM.render(
        <App name="test"/>,
        document.getElementById('root')
    );

});


class App extends React.Component {
    init(props) {
        var me = this;
        // Send an AJAX request
        return axios.get("api/cards").then(function (response) {
            // On success, 'data' contains a list of cards.
            var data = response.data;
            me.setState({
                cards: data.map(function (card) {
                    return <Card key={card.Id} data={card} />
                })
            });
        });
    }

    constructor(props) {
        super(props);
        var me = this;
        me.state = {
            cards: []
        };
        me.signalRConnection = $.connection;
        me.signalRConnection.hub.start().done(function () { });
        me.chatHub = me.signalRConnection.chatHub;
        me.init(props);
    }

    clickCard(card) {

    }

    getCard(Id) {

    }

    componentDidMount() {
        console.log("here?2");
    }

    componentWillUnmount() {
        console.log("here?3");
    }

    render() {
        return (
            <div>
                <div className="container">
                    <ChatWindow chatHub={this.chatHub} />
                </div>
                <div>
                    <h2>All Cards</h2>
                    <ul id="cards">
                        { this.state.cards }
                    </ul>
                </div>
            </div>
        );
    }

}

