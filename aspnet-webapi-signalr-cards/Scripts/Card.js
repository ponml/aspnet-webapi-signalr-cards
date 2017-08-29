import React from 'react';
import ReactDOM from 'react-dom';



//If you don't use something in render(), it shouldn't be in the state.
class Card extends React.Component {
    constructor(props) {
        super(props);
        var me = this;
        me.valueToDisplay = {
            1: "A",
            2: "2",
            3: "3",
            4: "4",
            5: "5",
            6: "6",
            7: "7",
            8: "8",
            9: "9",
            10: "10",
            11: "J",
            12: "Q",
            13: "K",
        };
    }

    componentDidMount() {
    }

    componentWillUnmount() {
    }


    render() {
        if (this.props.data) {
            var cardFront = "../Images/" + this.props.data.FrontImageFileName;
            var cardBackGround = {
                backgroundImage: "url(" + cardFront + ")"
            };
            var cardDisplayValue = this.valueToDisplay[this.props.data.Value] || "";

            return (
                <div className="card" style={cardBackGround}>
                    <div className="number-top">{cardDisplayValue}</div>
                    <div className="number-bot">{cardDisplayValue}</div>
                </div>
            );
        } else {
            return (null);
        }
    }
}

module.exports = Card;