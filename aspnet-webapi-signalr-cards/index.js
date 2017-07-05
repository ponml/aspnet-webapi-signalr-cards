import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import Card from './Scripts/Card.js'

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
        debugger;
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
        me.chat = $.connection.chatHub
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
                <div>
                    <h2>All Cards</h2>
                    <ul id="cards">
                        { this.state.cards }
                    </ul>
                </div>
                <div className="container">
                    <ChatWindow />
                </div>
            </div>
        );
    }

}

class ChatWindow extends React.Component {
    constructor(props) {
        super(props);
        var me = this;
        me.chat = $.connection.chatHub;
        me.state = {
            messages: [],
            msgBox: "",
            cardId: "",
            foundCard: null
        };

        this.handleCardSubmit = this.handleCardSubmit.bind(this);
        this.handleCardOnChange = this.handleCardOnChange.bind(this);
        this.handleMsgBoxSubmit = this.handleMsgBoxSubmit.bind(this);
        this.handleMsgBoxOnChange = this.handleMsgBoxOnChange.bind(this);

        me.chat.client.broadcastMessage = function (name, message) {
            // Html encode display name and message.
            var message = {
                name: name,
                msg: message
            };
            var messages = this.state.messages.push(message);
            this.setState({ messages: messages });
        };

        $.connection.hub.start().done(function () {

        });
    }

    handleCardSubmit(e) {
        var me = this;
        if (e.keyCode == 13) {
            return axios.get("api/cards", { params: { id: this.state.cardId } }).then(function (response) {
                me.setState({
                    foundCard: response.data
                });
            });
        }
    }

    handleCardOnChange(e) {
        var me = this;
        me.setState({
            cardId: e.target.value
        });
    }

    handleMsgBoxSubmit(e) {
        var me = this;
        if (e.keyCode == 13) {
            return axios.get(uri, { params: { id: me.state.cardId } }).then(function (response) {

            });
        }
    }

    handleMsgBoxOnChange(e) {
        var me = this;
        me.setState({
            msgBox: e.target.value
        });
    }


    render() {

        var foundCard = this.state.foundCard ? <Card data={this.state.foundCard} /> : null;
        return (
            <div>
                <input type="text" placeholder={"type here"} value={this.state.msgBox} onKeyUp={this.handleMsgBoxSubmit} onChange={this.handleMsgBoxOnChange} />
                <ul>
                    {
                        this.state.messages.map(msg => {
                            return
                            <li>
                                <span>msg.name</span>::<span>msg.msg</span>
                            </li>
                        })
                    }
                </ul>
                <input type="text" placeholder={"get card by id"} value={this.state.cardId} onKeyUp={this.handleCardSubmit} onChange={this.handleCardOnChange} />
                <div>
                    {foundCard}
                </div>
            </div>
        );
    }
}