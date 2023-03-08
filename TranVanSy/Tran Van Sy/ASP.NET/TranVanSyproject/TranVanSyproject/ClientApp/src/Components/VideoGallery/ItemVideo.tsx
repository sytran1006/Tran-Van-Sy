import React, { Component } from "react";
import Image from "../../Base/Image";

export interface ItemVideoProps {
  id: number;
  video: string;
}
interface ItemVideoState {}

export default class ItemVideo extends React.Component<
  ItemVideoProps,
  ItemVideoState
> {
  constructor(props: ItemVideoProps) {
    super(props);
    this.state = {};
  }

  render() {
    return <img className="videoGallery" src={this.props.video} />;
  }
}
