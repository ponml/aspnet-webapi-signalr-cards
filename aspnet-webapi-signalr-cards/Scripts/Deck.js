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
            cards: this.data.Cards.map(function (card) {
                return <Card key={card.Id} data={card} />
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
                <ul>
                    {this.state.cards}
                </ul>
            </div>
        )
    }
}

module.exports = Deck;