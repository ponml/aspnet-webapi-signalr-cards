import React from 'react';
import ReactDOM from 'react-dom';
import Card from './Card.js';


//If you don't use something in render(), it shouldn't be in the state.
class Deck extends React.Component {
    constructor(props) {
        super(props);
        var me = this;
        this.data = props.data;
        me.state = {
            cards: this.data.Cards.map(function (card, index) {
                return (
                    <li key={index}>
                        <div className="flex">
                            <Card key={card.Id} data={card} />
                        </div>
                    </li>
                );
            })
        };
    }

    componentDidMount() {
    }

    componentWillUnmount() {
    }


    render() {
        return (
            <div>
                <div> The deck {this.data.Name} has {this.data.Cards.length} cards, and id {this.data.Id} </div>
                <ol>
                    {this.state.cards}
                </ol>
            </div>
        )
    }
}

module.exports = Deck;