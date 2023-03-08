import React, { Component } from "react";
import "./News.scss";
import Image from "../../Base/Image";
import ElementContent from "./ItemNews";
import { dataNews } from "../Data/dataNews";

export interface ElementContentProps {
  newsData: newsData[];
}
export interface newsData {
  id: number;
  img: string;
  title: string;
  intruduction: string;
  iconDate: string;
  dateTime: string;
  resource: string;
  alt: string;
}
interface ElementContentState {
  itemToShow: number;
  item: number;
  itemCount: number;
  checkCountItem: boolean;
}

export class News extends Component<ElementContentProps, ElementContentState> {
  constructor(props: ElementContentProps) {
    super(props);
    this.state = {
      itemToShow: 4,
      item: 0,
      checkCountItem: false,
      itemCount: dataNews.length,
    };
  }
  ConditionShowMoreNews = () => {
    if (
      this.state.itemToShow >= 4 &&
      this.state.itemToShow < this.props.newsData.length
    ) {
      this.setState({
        itemToShow: this.state.itemToShow + 4,
        checkCountItem: true,
        itemCount: this.state.itemCount - 4,
      });
    }
    if (this.state.itemToShow >= this.props.newsData.length) {
      this.setState({
        checkCountItem: false,
        itemToShow: 4,
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
        itemCount: this.props.newsData.length,
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
      <div className="wrraper">
        <div className="wrraper__title">News</div>
        <div className="wrraper__content">
          {this.props.newsData
            .slice(0, this.state.itemToShow)
            .map((item, index) => (
              <ElementContent
                key={index}
                id={item.id}
                img={item.img}
                title={item.title}
                intruduction={item.intruduction}
                iconDate={item.iconDate}
                dateTime={item.dateTime}
                resource={item.resource}
                alt={item.alt}
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
export default News;
