import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import Card from './Card.js';

class ChatWindow extends React.Component {
    constructor(props) {
        super(props);
        var me = this;
        me.signalRConnection = $.connection;
        me.signalRConnection.hub.start().done(function () { });
        me.chatHub = me.signalRConnection.chatHub;

        me.state = {
            messages: [],
            msgBoxValue: "",
        };

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

    render() {

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
                </div>
            </div>
        );
    }
}

module.exports = ChatWindow;