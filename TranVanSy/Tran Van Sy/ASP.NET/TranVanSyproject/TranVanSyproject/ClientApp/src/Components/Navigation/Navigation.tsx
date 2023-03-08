import React, { Component } from "react";
import "./index.scss";
import Image from "../../Base/Image";
interface NavProps {}
interface NavState {
  nav: any[];
  click: boolean;
}
export default class Navigation extends React.Component<NavProps, NavState> {
  constructor(props: NavProps) {
    super(props);
    this.state = {
      nav: [
        { name: "About" },
        { name: "Services" },
        { name: "Products" },
        { name: "List" },
        { name: "Support" },
      ],
      click: false,
    };
  }
  view = () => {
    if (this.state.click === true) {
      return (
        <div className="ShowMenu__item">
          <div className="ShowMenu__item-text">About</div>
          <div className="ShowMenu__item-text">Service</div>
          <div className="ShowMenu__item-text">Product</div>
          <div className="ShowMenu__item-text">List</div>
          <div className="ShowMenu__item-text">Support</div>
        </div>
      );
    }
  };
  click = () => {
    this.setState({
      click: true,
    });
  };
  doubleClick = () => {
    this.setState({
      click: false,
    });
  };
  render() {
    return (
      <div className="nav">
        <div className="nav-logo">
          <img src={Image.logo} alt="logo" />
        </div>
        <div className="nav-items">
          {this.state.nav.map((item, index) => {
            return (
              <div key={index} className="nav-item">
                {item.name}
              </div>
            );
          })}
        </div>
        {/* <div className="ShowMenu">
          {this.view()}
          <div
            className="iconmenu"
            onClick={() => this.click()}
            onDoubleClick={() => this.doubleClick()}
          >
            <div className="iconmenu__wrrap">
              <img className="ShowMenu__icon" src={Image.icon_2} alt="cc" />
            </div>
          </div>
        </div> */}
      </div>
    );
  }
}
