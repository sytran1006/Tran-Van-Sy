import React, { Component } from "react";
import "./Anouncement.scss";
import Image from "../../Base/Image";
import { dataAnouncement } from "../Data/dataAnnouncement";
import ElementContent from "./ElementContent";
import { eventNames } from "process";
import AddModal from "./AddModal";
export interface ElementContentProps {
  /*// announcementData: anouncementData[];*/
}
export interface anouncementData {
  id: number;
  img: any;
  title: string;
  introduction: string;
  dateTimeUse: string;
  resourceUse: string;
}
interface ElementContentState {
  itemToShow: number;
  itemCount: number;
  checkCountItem: boolean;
  dataAno: any;
  addModalShow: boolean;
  title: string;
  introduction: string;
  img: string;
  datetimeuse: string;
  resourceuse: string;
}
export class Anouncement extends Component<
  ElementContentProps,
  ElementContentState
> {
  constructor(props: ElementContentProps) {
    super(props);
    this.state = {
      itemToShow: 4,
      itemCount: dataAnouncement.length,
      checkCountItem: true,
      addModalShow: false,
      dataAno: [],
      title: "",
      introduction: "",
      img: "",
      datetimeuse: "",
      resourceuse: "",
    };
  }
  refreshList() {
    fetch("https://localhost:44401/api/Anouncements")
      .then((response) => response.json())
      .then((data) => {
        this.setState({
          dataAno: data,
        });
      });
  }
  componentDidMount() {
    this.refreshList();
  }
  componentDidUpdate() {
    this.refreshList();
  }
  ShowModal() {
    if (this.state.addModalShow == true) {
      return <AddModal></AddModal>;
    }
  }
  ConditionShowMoreNews = () => {
    if (
      this.state.itemToShow >= 4 &&
      this.state.itemToShow < this.state.dataAno.length
    ) {
      this.setState({
        itemToShow: this.state.itemToShow + 4,
        checkCountItem: true,
        itemCount: this.state.itemCount - 4,
      });
    }
    if (this.state.itemToShow >= this.state.dataAno.length) {
      this.setState({
        checkCountItem: false,
        itemToShow: 4,
      });
    }
  };
  showMore = () => {
    if (this.state.checkCountItem == true || this.state.itemCount > 0) {
      return (
        // onClick={() => this.ConditionShowMoreNews()
        <div className="wrraper__view">
          <div className="wrraper__view-text">View More</div>
          <img className="wrraper__view-img" src={Image.arrowicon} alt="" />
        </div>
      );
      //this.state.checkCountItem==false || this.state.itemCount==0 ||this.state.itemCount==this.state.dataAnouncement.length
    } else if (this.state.checkCountItem == false) {
      this.setState({
        itemCount: this.state.dataAno.length,
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
        <div className="wrraper__title">
          <span>Anouncement</span>
          <div
            className="wrraper__title-icon"
            onClick={() => this.setState({ addModalShow: true })}
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="20"
              height="20"
              fill="currentColor"
              className="bi bi-plus-circle"
              viewBox="0 0 16 16"
            >
              <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z" />
              <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z" />
            </svg>
          </div>
        </div>
        <div className="wrraper__content">
          {this.state.dataAno
            .slice(0, this.state.itemToShow)
            .map((item: anouncementData, index: any) => (
              <ElementContent
                key={index}
                id={item.id}
                img={item.img}
                title={item.title}
                introduction={item.introduction}
                /*iconDate={item.iconDate}*/
                dateTimeUse={item.dateTimeUse}
                resourceUse={item.resourceUse}
                /*alt={item.alt}*/
              />
            ))}
        </div>
        {this.ShowModal()}
        <div onClick={() => this.ConditionShowMoreNews()}>
          {this.showMore()}
        </div>
      </div>
    );
  }
}
export default Anouncement;
