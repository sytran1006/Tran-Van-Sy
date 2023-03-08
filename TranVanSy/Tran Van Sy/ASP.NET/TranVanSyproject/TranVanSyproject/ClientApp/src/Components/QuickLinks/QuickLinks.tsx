import React, { Component } from "react";
import Image from "../../Base/Image";
import { dataQuickLinks } from "../Data/dataQuickLinks";
import "./QuickLinks.scss";

export interface QuickLinkProps {
  //quickLinkData: quicklinkData[];
}
export interface quicklinkData {
  //id: number;
  img: string;
  title: string;
}
interface QuickLinkState {
  itemToShow: number;
  item: number;
  itemCount: number;
  expanded: boolean;
}
export interface ElementQuickProps {
  // id:number;
  img: string;
  title: string;
}
interface ElementQuickState {}
class QuickLink extends React.Component<ElementQuickProps, ElementQuickState> {
  constructor(props: ElementQuickProps) {
    super(props);
    this.state = {};
  }

  render() {
    return (
      <div className="props__link">
        <div className="props__link-wrrap">
          <div className="props__link-wrrap-img-first">
            <div className="props__link-wrrap-img">
              <img className="props__link-img" src={this.props.img} alt="" />
            </div>
          </div>
          <div className="props__link-wrrap-text">
            <div className="props__link-text">{this.props.title}</div>
          </div>
        </div>
      </div>
    );
  }
}
export class QuickLinks extends Component<QuickLinkProps, QuickLinkState> {
  constructor(props: QuickLinkProps) {
    super(props);
    this.state = {
      itemToShow: 4,
      item: 0,
      itemCount: dataQuickLinks.length,
      expanded: false,
    };
  }
  render() {
    return (
      <div className="wrraperLink">
        <div className="wrraperlink__title">Quick Links</div>
        <div className="wrraperLink__content">
          <div className="wrraperLink__content-top">
            <QuickLink img={Image.icon} title="Training" />
            <QuickLink img={Image.icon_1} title="Organization" />
            <QuickLink img={Image.icon_2} title="Task" />
          </div>
          <div className="wrraperLink__content-between">
            <QuickLink img={Image.icon_3} title="Global Sales" />
            <QuickLink img={Image.icon_4} title="Birthday" />
            <QuickLink img={Image.icon_5} title="Health" />
          </div>
          <div className="wrraperLink__content-bottom">
            <QuickLink img={Image.icon_6} title="Service Desk" />
            <QuickLink img={Image.icon_7} title="Truck" />
            <QuickLink img={Image.icon_8} title="Idea" />
          </div>
        </div>
      </div>
    );
  }
}
export default QuickLinks;
