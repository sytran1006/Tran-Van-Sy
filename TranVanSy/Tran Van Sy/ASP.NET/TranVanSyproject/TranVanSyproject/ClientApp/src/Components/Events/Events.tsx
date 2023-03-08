import React, { Component } from "react";
import Image from "../../Base/Image";
import { dataEvents } from "../Data/dataEvents";
import "./Events.scss";
import Event from "./ItemEvents";

export interface eventProps {
  dataEvents: dataEvents[];
}
export interface dataEvents {
  id: number;
  number: string;
  day: string;
  title: string;
  img: string;
  time: string;
}
export interface eventState {
  itemToShow: number;
  item: number;
  itemCount: number;
  checkCountItem: boolean;
}

export class Events extends Component<eventProps, eventState> {
  constructor(props: eventProps) {
    super(props);
    this.state = {
      itemToShow: 4,
      item: 0,
      itemCount: dataEvents.length,
      checkCountItem: false,
    };
  }
  ConditionShowMoreNews = () => {
    if (
      this.state.itemToShow >= 4 &&
      this.state.itemToShow < this.props.dataEvents.length
    ) {
      this.setState({
        itemToShow: this.state.itemToShow + 4,
        checkCountItem: true,
        itemCount: this.state.itemCount - 4,
      });
    }
    if (this.state.itemToShow >= this.props.dataEvents.length) {
      this.setState({
        checkCountItem: false,
        itemToShow: 4,
      });
    }
  };
  showMore = () => {
    if (this.state.checkCountItem == true || this.state.itemCount > 0) {
      return (
        <div
          className="wrraper__view"
          onClick={() => this.ConditionShowMoreNews()}
        >
          <div className="wrraper__view-text">View More</div>
          <img className="wrraper__view-img" src={Image.arrowicon} alt="" />
        </div>
      );
      //this.state.checkCountItem==false || this.state.itemCount==0 ||this.state.itemCount==this.state.dataAnouncement.length
    } else if (this.state.checkCountItem == false) {
      this.setState({
        itemCount: this.props.dataEvents.length,
      });
      return (
        <div className="wrraper__view">
          <div className="wrraper__view-text">View Less</div>
          <img src={Image.arrowicon} alt="" />
        </div>
      );
    }
  };

  render() {
    return (
      <div className="wrraperEvents">
        <div className="wrraperEvents__title ">Events</div>
        <div className="wrraperEvents__content">
          {this.props.dataEvents
            .slice(0, this.state.itemToShow)
            .map((item, index) => (
              <Event
                key={index}
                id={item.id}
                number={item.number}
                day={item.day}
                title={item.title}
                img={item.img}
                time={item.time}
              />
            ))}
        </div>
        <div onClick={() => this.ConditionShowMoreNews()}>
          {this.showMore()}
        </div>
      </div>
    );
  }
}
export default Events;
