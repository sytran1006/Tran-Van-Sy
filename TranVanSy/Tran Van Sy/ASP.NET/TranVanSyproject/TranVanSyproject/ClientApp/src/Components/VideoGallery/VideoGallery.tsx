import React, { Component } from "react";
import Image from "../../Base/Image";
import { dataVideoGallery } from "../Data/dataVideoGallery";
import "./VideoGallery.scss";
import ItemVideo from "./ItemVideo";

export interface ItemVideoProps {
  videoGalleryData: videoGalleryData[];
}
export interface videoGalleryData {
  id: number;
  video: string;
}
interface ItemVideoState {
  itemToShow: number;
  item: number;
  itemCount: number;
  checkCountItem: boolean;
}
export class VideoGallery extends Component<ItemVideoProps, ItemVideoState> {
  constructor(props: ItemVideoProps) {
    super(props);
    this.state = {
      itemToShow: 4,
      item: 0,
      itemCount: dataVideoGallery.length,
      checkCountItem: false,
    };
  }
  ConditionShowMoreNews = () => {
    if (
      this.state.itemToShow >= 4 &&
      this.state.itemToShow < this.props.videoGalleryData.length
    ) {
      this.setState({
        itemToShow: this.state.itemToShow + 4,
        checkCountItem: true,
        itemCount: this.state.itemCount - 4,
      });
    }
    if (this.state.itemToShow >= this.props.videoGalleryData.length) {
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
        itemCount: this.props.videoGalleryData.length,
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
        <div className="wrraper__title-video">Video Gallery</div>
        <div className="wrraper__content-video">
          {this.props.videoGalleryData
            .slice(0, this.state.itemToShow)
            .map((item, index) => (
              <ItemVideo key={index} id={item.id} video={item.video} />
            ))}
        </div>
        <div onClick={() => this.ConditionShowMoreNews()}>
          {this.showMore()}
        </div>
      </div>
    );
  }
}
export default VideoGallery;
