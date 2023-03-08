import React, { Component } from "react";
import "../Anouncement/Anouncement.scss";
import Image from "../../Base/Image";

export interface ElementContentProps {
  id: number;
  img: string;
  title: string;
  intruduction: string;
  iconDate: string;
  dateTime: string;
  resource: string;
  alt: string;
}
interface ElementContentState {}

export default class ElementContent extends Component<
  ElementContentProps,
  ElementContentState
> {
  constructor(props: ElementContentProps) {
    super(props);
    this.state = {};
  }

  render() {
    return (
      <div className="props__item">
        <div className="props__item-wrrap">
          <img
            className="props__item-wrrap-left"
            src={this.props.img}
            alt={this.props.alt}
          />
          <div className="props__item-wrrap-right">
            <div className="title">{this.props.title}</div>
            <div className="introduction">{this.props.intruduction}</div>
            <div className="dateAndResource">
              <img className="iconDate" src={this.props.iconDate} />
              <div className="date">{this.props.dateTime}</div>
              {/* <div className="resource">{this.props.resource}</div> */}
            </div>
          </div>
        </div>
      </div>
    );
  }
}
