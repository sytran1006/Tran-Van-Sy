import React, { Component } from "react";
import { dataHowDoI } from "../Data/dataHowDoI";
import Image from "../../Base/Image";
import "./HowDoI.scss";
import ElementHowDoI from "./ItemHowDoI";
import PropTypes from "prop-types";
import "../Anouncement/Anouncement.scss";

export interface howDoIData {
  id: number;
  iconQuestion: string;
  iconAnswer: string;
  question: string;
  answer: string;
}

export interface HowDoIProps {
  howDoIData: howDoIData[];
}
export interface HowDoIState {
  itemToShow: number;
  item: 0;
  itemCount: number;
  checkCountItem: boolean;
  click: boolean;
  change: string;
  viewList: boolean;
  search: boolean;
  data: howDoIData[];
}
export class HowDoI extends Component<HowDoIProps, HowDoIState> {
  constructor(props: HowDoIProps) {
    super(props);
    this.state = {
      itemToShow: 10,
      item: 0,
      itemCount: dataHowDoI.length,
      checkCountItem: false,
      click: false,
      change: "",
      viewList: true,
      search: true,
      data: this.props.howDoIData,
    };
  }
  changeInput = (event: any) => {
    this.setState({
      change: event.target.value.toLowerCase(),
    });
    console.log(this.state.change);
  };

  ConditionShowMoreNews = () => {
    if (
      this.state.itemToShow >= 10 &&
      this.state.itemToShow < this.props.howDoIData.length
    ) {
      this.setState({
        itemToShow: this.state.itemToShow + 4,
        checkCountItem: true,
        itemCount: this.state.itemCount - 10,
      });
    }
    if (this.state.itemToShow >= this.props.howDoIData.length) {
      this.setState({
        checkCountItem: false,
        itemToShow: 10,
      });
    }
  };
  showMore = () => {
    if (this.state.checkCountItem == true || this.state.itemCount > 0) {
      return (
        <div className="wrraper__view">
          <div className="wrraper__view-text">View More</div>
          <img src={Image.arrowicon} alt="" />
        </div>
      );
      //this.state.checkCountItem==false || this.state.itemCount==0 ||this.state.itemCount==this.state.dataAnouncement.length
    } else if (this.state.checkCountItem == false) {
      this.setState({
        itemCount: this.props.howDoIData.length,
      });
      return (
        <div className="wrraper__view">
          <div className="wrraper__view-text">View Less</div>
          <img src={Image.arrowicon} alt="" />
        </div>
      );
    }
  };

  viewAllList = () => {
    if (this.state.change == "") {
      return (
        <>
          {this.props.howDoIData
            .slice(0, this.state.itemToShow)
            .map((item, index) => (
              <ElementHowDoI
                key={index}
                id={item.id}
                iconQuestion={item.iconQuestion}
                iconAnswer={item.iconAnswer}
                question={item.question}
                answer={item.answer}
              />
            ))}
        </>
      );
    } else {
      return (
        <>
          {this.props.howDoIData
            .filter((item) => {
              if (item.question.toLowerCase().includes(this.state.change)) {
                return item;
              }
            })
            .slice(0, this.state.itemToShow)
            .map((item, index) => (
              <ElementHowDoI
                key={index}
                id={item.id}
                iconQuestion={item.iconQuestion}
                iconAnswer={item.iconAnswer}
                question={item.question}
                answer={item.answer}
              />
            ))}
        </>
      );
    }
  };

  render() {
    return (
      <div className="wrraperHowDoI">
        <div className="wrraperHowDoI__title ">How Do I</div>
        <div className="howDoIFind">
          <img className="howDoIFind__icon-find" src={Image.search} />
          <input
            className="howDoIFind__input"
            type="text"
            placeholder="Find Questions"
            onChange={(event) => {
              this.changeInput(event);
            }}
          />
        </div>
        <div className="wrraperHowDoI__content">{this.viewAllList()}</div>
        <div onClick={() => this.ConditionShowMoreNews()}>
          {this.showMore()}
        </div>
      </div>
    );
  }
}
export default HowDoI;
