import React, { Component } from "react";

export interface itemEventPros {
  id: number;
  number: string;
  day: string;
  title: string;
  img: string;
  time: string;
}
interface itemEventState {}
export default class Event extends Component<itemEventPros, itemEventState> {
  constructor(props: itemEventPros) {
    super(props);
    this.state = {};
  }
  render() {
    return (
      <div className="event">
        <div className="event__left">
          <div className="event__left-wrrap-day">
            <div className="event__left-number">{this.props.number}</div>
            <div className="event__left-day">{this.props.day}</div>
          </div>
          <div className="event__left-wrrap-time">
            <div className="event__rights">
              <div className="event__right-wrraps">
                <div className="event__right-titles">{this.props.title}</div>
                <div className="event__right-contents">
                  <img
                    className="event__right-content-icons"
                    src={this.props.img}
                    alt=""
                  />
                  <div className="event__right-content-times">
                    {this.props.time}
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="event__right">
          <div className="event__right-wrrap">
            <div className="event__right-title">{this.props.title}</div>
            <div className="event__right-content">
              <img
                className="event__right-content-icon"
                src={this.props.img}
                alt=""
              />
              <div className="event__right-content-time">{this.props.time}</div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
