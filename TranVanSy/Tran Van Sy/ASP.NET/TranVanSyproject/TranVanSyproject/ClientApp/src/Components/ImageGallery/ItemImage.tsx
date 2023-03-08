import React, { Component } from "react";
import Image from "../../Base/Image";

export interface ItemImageProps {
  id: number;
  img: string;
}
interface ItemImageState {}

export default class ItemImage extends React.Component<
  ItemImageProps,
  ItemImageState
> {
  constructor(props: ItemImageProps) {
    super(props);
    this.state = {};
  }

  render() {
    return <img className="imgGallery" src={this.props.img} />;
  }
}
