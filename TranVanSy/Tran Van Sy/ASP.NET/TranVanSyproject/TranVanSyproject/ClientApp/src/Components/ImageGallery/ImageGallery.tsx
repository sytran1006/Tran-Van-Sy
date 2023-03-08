import React, { Component } from "react";
import Image from "../../Base/Image";
import "./ImageGallery.scss";
import { dataImageGallery } from "../Data/dataImageGallery";
import ItemImage from "./ItemImage";

export interface ItemImageProps {
  imageGalleryData: imageGalleryData[];
}
export interface imageGalleryData {
  id: number;
  img: string;
}
interface ItemImageState {
  itemToShow: number;
  item: number;
  itemCount: number;
  checkCountItem: boolean;
}
export class ImageGallery extends Component<ItemImageProps, ItemImageState> {
  constructor(props: ItemImageProps) {
    super(props);
    this.state = {
      itemToShow: 4,
      item: 0,
      itemCount: dataImageGallery.length,
      checkCountItem: false,
    };
  }
  ConditionShowMoreNews = () => {
    if (
      this.state.itemToShow >= 4 &&
      this.state.itemToShow < this.props.imageGalleryData.length
    ) {
      this.setState({
        itemToShow: this.state.itemToShow + 4,
        checkCountItem: true,
        itemCount: this.state.itemCount - 4,
      });
    }
    if (this.state.itemToShow >= this.props.imageGalleryData.length) {
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
        itemCount: this.props.imageGalleryData.length,
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
        <div className="wrraper__title-img">Image Gallery</div>
        <div className="wrraper__content-img">
          {this.props.imageGalleryData
            .slice(0, this.state.itemToShow)
            .map((item, index) => (
              <ItemImage key={index} id={item.id} img={item.img} />
            ))}
        </div>
        <div onClick={() => this.ConditionShowMoreNews()}>
          {this.showMore()}
        </div>
      </div>
    );
  }
}
export default ImageGallery;
