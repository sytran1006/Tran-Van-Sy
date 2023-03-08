import React, { Component } from "react";
import Image from "./Image";
import "./Menu.scss";
export default class Menu extends Component {
  render() {
    return (
      <div className="overlay">
        <div className="menu">
          <div className="ShowMenu">
            <div className="iconmenu">
              <div className="iconmenu__wrrap">
                <img className="ShowMenu__icon" src={Image.icon_2} alt="cc" />
              </div>
            </div>
            <div className="ShowMenu__item">
              <div className="ShowMenu__item-text">About</div>
              <div className="ShowMenu__item-text">Service</div>
              <div className="ShowMenu__item-text">Product</div>
              <div className="ShowMenu__item-text">List</div>
              <div className="ShowMenu__item-text">Support</div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
