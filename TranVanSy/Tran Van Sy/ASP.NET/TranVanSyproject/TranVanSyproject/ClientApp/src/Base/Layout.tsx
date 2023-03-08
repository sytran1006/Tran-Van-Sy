import React from "react";
import "./layout.scss";
import Navigation from "../Components/Navigation/Navigation";
import Anouncement from "../Components/Anouncement/Anouncement";
import News from "../Components/News/News";
import ImageGallery from "../Components/ImageGallery/ImageGallery";
import VideoGallery from "../Components/VideoGallery/VideoGallery";
import DocumentGallery from "../Components/DocumentGallery/DocumentGallery";
import Quicklinks from "../Components/QuickLinks/QuickLinks";
import Events from "../Components/Events/Events";
import { dataHowDoI } from "../Components/Data/dataHowDoI";
import { dataAnouncement } from "../Components/Data/dataAnnouncement";
import { dataNews } from "../Components/Data/dataNews";
import { dataImageGallery } from "../Components/Data/dataImageGallery";
import { dataVideoGallery } from "../Components/Data/dataVideoGallery";
import { dataQuickLinks } from "../Components/Data/dataQuickLinks";
import HowDoI from "../Components/HowDoI/HowDoI";
import { dataEvents } from "../Components/Data/dataEvents";

export default class Layout extends React.Component {
  render() {
    return (
      <div className="portal-homepage">
        <div className="wrap">
          <div className="header">
            <Navigation></Navigation>
          </div>
          <div className="content">
            <div className="content__left">
              <div id="announcement">
                <Anouncement></Anouncement>
              </div>
              <div id="news">
                <News newsData={dataNews}></News>
              </div>
              <div id="image-gallery">
                <ImageGallery
                  imageGalleryData={dataImageGallery}
                ></ImageGallery>
              </div>
              <div id="video-gallery">
                <VideoGallery
                  videoGalleryData={dataVideoGallery}
                ></VideoGallery>
              </div>
              <div id="document-gallery">
                <DocumentGallery></DocumentGallery>
              </div>
            </div>
            <div className="content__right">
              <div id="quick-links">
                <Quicklinks></Quicklinks>
              </div>
              <div id="events">
                <Events dataEvents={dataEvents}></Events>
              </div>
              <div id="how-do-i">
                <HowDoI howDoIData={dataHowDoI}></HowDoI>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
