import React, { Component } from "react";

interface UpdateProps {
  title: string;
  introduction: string;
  img: string;
  dateTimeUse: string;
  resourceUse: string;
  id: number;
}
interface UpdateState {
  title: string;
  introduction: string;
  img: string;
  dateTimeUse: string;
  resourceUse: string;
  dataAno: any;
  id: number;
  id1: number;
}
export default class UpdateModal extends Component<UpdateProps, UpdateState> {
  constructor(props: UpdateProps) {
    super(props);
    this.state = {
      title: this.props.title,
      introduction: this.props.introduction,
      img: this.props.img,
      dateTimeUse: this.props.dateTimeUse,
      resourceUse: this.props.resourceUse,
      id: this.props.id,
      dataAno: [],
      id1: 0,
    };
  }
  Update(id: number) {
    const requestOptions = {
      method: "PUT",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        /*AnouncementId: null,*/
        id: this.state.id,
        title: this.state.title,
        introduction: this.state.introduction,
        img: this.state.img,
        dateTimeUse: this.state.dateTimeUse,
        resourceUse: this.state.resourceUse,
      }),
    };
    fetch("https://localhost:44401/api/Anouncements/" + id, requestOptions)
      .then((res) => res.json())
      .then(
        (result) => {
          alert("Update Successful !");
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
    const { title, introduction, img, dateTimeUse, resourceUse } = this.state;
    return (
      <div className="modal">
        <div className="modal__form">
          <form className="form">
            <div className="form__title">Update Anouncement</div>
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
                  type="text"
                  id="Img"
                  name="title"
                  placeholder="TranVanSy"
                  value={img}
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
                onClick={() => this.Update(this.props.id)}
              >
                Update
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
