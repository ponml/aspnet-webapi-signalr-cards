import React from 'react';
import ReactDOM from 'react-dom';

class ChatWindow extends React.Component {
    constructor(props) {
        super(props);
        var me = this;
        me.chatHub = props.chatHub;
        me.state = {
            messages: [],
            msgBoxValue: "",
            cardId: "",
            foundCard: null
        };

        me.handleCardSubmit = me.handleCardSubmit.bind(me);
        me.handleCardOnChange = me.handleCardOnChange.bind(me);
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

    handleCardSubmit(e) {
        var me = this;
        if (e.keyCode == 13) {
            return axios.get("api/cards", { params: { id: me.state.cardId } }).then(function (response) {
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

        var foundCard = this.state.foundCard ? <Card data={this.state.foundCard} /> : null;
        return (
            <div>
                <input type="text" placeholder={"type here"} value={this.state.msgBoxValue} onKeyUp={this.handleMsgBoxSubmit} onChange={this.handleMsgBoxOnChange} />
                <ul>
                    {
                        this.state.messages.map((msg, index) => {
                            return (
                                <li key={index}>
                                    <span>{msg.name}</span>
                                    <span>{"::"}</span>
                                    <span>{msg.msg}</span>
                                </li>
                            )
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

module.exports = ChatWindow;