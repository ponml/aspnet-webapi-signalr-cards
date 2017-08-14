import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import Card from './Card.js';

class ChatWindow extends React.Component {
    constructor(props) {
        super(props);
        var me = this;
        me.chatHub = props.chatHub;
        me.state = {
            messages: [],
            msgBoxValue: "",
            cardInsertValue: "",
            cardId: "",
            foundCard: null,
            cardNotFound: "",
            newCard: null
        };

        me.handlePostCardOnChange = me.handlePostCardOnChange.bind(me);
        me.handlePostCardSubmit = me.handlePostCardSubmit.bind(me);
        me.handleGetCardSubmit = me.handleGetCardSubmit.bind(me);
        me.handleGetCardOnChange = me.handleGetCardOnChange.bind(me);
        me.handleMsgBoxSubmit = me.handleMsgBoxSubmit.bind(me);
        me.handleMsgBoxOnChange = me.handleMsgBoxOnChange.bind(me);

        me.chatHub.client.broadcastMessage = function (name, message) {
            // Html encode display name and message.
            var currentMessages = me.state.messages;
            var newMessage = {
                name: name,
                msg: message
            };
            currentMessages.push(newMessage);
            me.setState({ messages: currentMessages });
        };
    }

    handleGetCardSubmit(e) {
        var me = this;
        if (e.keyCode == 13) {
            return axios.get("api/cards", { params: { id: me.state.cardId } }).then(function (response) {
                me.setState({
                    foundCard: response.data
                });
            }, function (error) {
                me.setState({
                    foundCard: {
                        Id: -1,
                        Name: "Card Not Found",
                        Value: "None"
                    }
                });
            });
        }
    }

    handleGetCardOnChange(e) {
        var me = this;
        me.setState({
            cardId: e.target.value
        });
    }

    handleMsgBoxSubmit(e) {
        var me = this;
        if (e.keyCode == 13) {
            me.chatHub.server.send(me.chatHub.connection.id, me.state.msgBoxValue);
            me.setState({
                msgBoxValue: ""
            });
        }
    }

    handleMsgBoxOnChange(e) {
        var me = this;
        me.setState({
            msgBoxValue: e.target.value
        });
    }

    handlePostCardSubmit(e) {
        var me = this;
        var payload;
        try {
            payload = JSON.parse(me.state.cardInsertValue);
        } catch (e) {
            console.log("couldn't parse card JSON");
        }
        if (payload) {
            if (Array.isArray(payload)) {
                payload.forEach(function (card) {
                    card.DeckId = "1";
                    delete card.Id;
                    axios.post("api/cards", card);
                });
            } else {
                payload.DeckId = "1";
                delete payload.Id;
                return axios.post("api/cards", payload).then(function (response) {
                    me.setState({
                        newCard: response.data
                    });
                });
            }
        }
    }

    handlePostCardOnChange(e) {
        var me = this;
        me.setState({
            cardInsertValue: e.target.value
        });
    }


    render() {

        var foundCard = this.state.foundCard ? <Card data={this.state.foundCard} /> : null;
        var newCard = this.state.newCard ? <Card data={this.state.newCard} /> : null;
        var messages = this.state.messages.map((msg, index) => {
            return (
                <li key={index}>
                    <span>{msg.name}</span>
                    <span>{"::"}</span>
                    <span>{msg.msg}</span>
                </li>
            )
        });
        return (
            <div>
                <div>
                    <h1>Messages</h1>
                    <input type="text" placeholder={"type here"} value={this.state.msgBoxValue} onKeyUp={this.handleMsgBoxSubmit} onChange={this.handleMsgBoxOnChange} />
                    <ul>
                        { messages }
                    </ul>
                    <input type="text" placeholder={"get card by id"} value={this.state.cardId} onKeyUp={this.handleGetCardSubmit} onChange={this.handleGetCardOnChange} />
                </div>
                <div>
                    <h1>Get Card</h1>
                    <div>
                        <Card data={this.state.foundCard} />
                    </div>
                </div>
                <div>
                    <h1>Insert Card</h1>
                    <textarea value={this.state.cardInsertValue} onChange={this.handlePostCardOnChange}></textarea>
                    <button onClick={this.handlePostCardSubmit}>Post</button>
                    <div>
                        {newCard}
                    </div>
                </div>
            </div>
        );
    }
}

module.exports = ChatWindow;