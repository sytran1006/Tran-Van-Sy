import React, { Component } from "react";
import Image from "../../Base/Image";
import "./HowDoI.scss";

export interface ItemHowDoIProps {
  id: number;
  iconQuestion: string;
  iconAnswer: string;
  question: string;
  answer: string;
}
interface ItemHowDoIState {
  click: boolean;
  classClick: string;
  icon: string;
}

export default class ElementHowDoI extends React.Component<
  ItemHowDoIProps,
  ItemHowDoIState
> {
  constructor(props: ItemHowDoIProps) {
    super(props);
    this.state = {
      click: false,
      classClick: "howDoIItem__content",
      icon: this.props.iconQuestion,
    };
  }
  ClickQuestion = () => {
    if (this.state.click === true) {
      return (
        <div className="howDoI__answer-wrrap">
          <div className="howDoI__answer-a">A:</div>
          <div className="howDoI__answer">{this.props.answer}</div>
        </div>
      );
    }
  };
  DoubleClick = () => {
    this.setState({
      click: false,
      classClick: "howDoIItem__content",
      icon: this.props.iconQuestion,
    });
  };
  render() {
    return (
      <div
        className="howDoItem"
        onClick={() =>
          this.setState({
            click: true,
            classClick: "click",
            icon: this.props.iconAnswer,
          })
        }
        onDoubleClick={() => this.DoubleClick()}
      >
        <div className={this.state.classClick}>
          <div>
            <img
              className="howDoI__icon-question"
              src={this.state.icon}
              alt="cc"
            />
          </div>
          <div className="howDoI__question">{this.props.question}</div>
        </div>
        {this.ClickQuestion()}
      </div>
    );
  }
}
