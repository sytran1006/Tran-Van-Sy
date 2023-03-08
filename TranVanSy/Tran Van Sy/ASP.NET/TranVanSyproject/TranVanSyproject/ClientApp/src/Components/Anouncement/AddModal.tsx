import React, { Component } from "react";

interface AddProp {}
interface AddState {
  title: string;
    introduction: string;
    img: string;
  dateTimeUse: string;
  resourceUse: string;
  dataAno: any;
  id: number;
}
export default class AddDepModal extends Component<AddProp, AddState> {
  constructor(props: AddProp) {
    super(props);
    this.state = {
      title: "",
      introduction: "",
      img:"",
      dateTimeUse: "",
      resourceUse: "",
      dataAno: [],
      id: 0,
    };
  }
  Add() {
    const requestOptions = {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        /*AnouncementId: null,*/
        title: this.state.title,
        introduction: this.state.introduction,
        img: this.state.img,
        dateTimeUse: this.state.dateTimeUse,
        resourceUse: this.state.resourceUse,
      }),
    };
    fetch("https://localhost:44401/api/Anouncements", requestOptions)
      .then((res) => res.json())
      .then(
        (result) => {
          alert("Add Successful !");
        },
        (error) => {
          alert("Failed");
        }
      );
    }
    AddImg() {
        const requestOptions = {
            method: "POST",
            body: JSON.stringify({
                img: this.state.img,
            }),
        };
        fetch("https://localhost:44401/api/Anouncements/upload", requestOptions)
            .then((res) => res.json())
            .then(
                (result) => {
                    alert("Add Successful !");
                },
                (error) => {
                    alert("Failed");
                }
            );
    }
  changeTitle = (e: any) => {
    this.setState({ title: e.target.value });
  };
  changeIntroduction = (e: any) => {
    this.setState({ introduction: e.target.value });
  };
  changeImg = (e: any) => {
    this.setState({ img: e.target.value });
  };
  changeDatetimeUse = (e: any) => {
    this.setState({ dateTimeUse: e.target.value });
  };
  changeResourceUse = (e: any) => {
    this.setState({ resourceUse: e.target.value });
  };
  render() {
    const { id, title, introduction, img, dateTimeUse, resourceUse } =
      this.state;
    return (
      <div className="modal">
        <div className="modal__form">
          <form className="form">
            <div className="form__title">Add Anouncement</div>
            <div className="form__wrrap">
              <div className="form__wrrap-left">
                <label htmlFor="title">title </label>
                <br></br>
                <input
                  type="text"
                  id="title"
                  name="title"
                  placeholder="TranVanSy"
                  value={title}
                  onChange={this.changeTitle}
                />
                <br></br>
                <label htmlFor="introduction">introduction</label>
                <br></br>
                <input
                  type="text"
                  id="introduction"
                  name="introduction"
                  placeholder="......."
                  value={introduction}
                  onChange={this.changeIntroduction}
                />
              </div>
              <div className="form__wrrap-right">
                <label htmlFor="Img"> img</label>
                <br></br>
                <input
                                type="file"
                                id="Img"
                                name="title"
                                placeholder="TranVanSy"
                                onClick={() => this.AddImg()}
                                onChange={this.changeImg}
                />
                <br></br>
                <label htmlFor="DatetimeUse">dateTimeUse</label>
                <br></br>
                <input
                  type="text"
                  id="DatetimeUse"
                  name="title"
                  placeholder="TranVanSy"
                  value={dateTimeUse}
                  onChange={this.changeDatetimeUse}
                />
                <br></br>
                <label htmlFor="ResourceUse">resourceUse</label>
                <br></br>
                <input
                  type="text"
                  id="ResourceUse"
                  name="title"
                  placeholder="TranVanSy"
                  value={resourceUse}
                  onChange={this.changeResourceUse}
                />
              </div>
            </div>
            <div className="form__bottom">
              <button
                className="form__bottom-add"
                type="button"
                onClick={() => this.Add()}
              >
                Add
              </button>
              <button className="form__bottom-close" type="submit">
                Close
              </button>
            </div>
          </form>
        </div>
      </div>
    );
  }
}
