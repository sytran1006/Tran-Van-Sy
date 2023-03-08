import React, { Component } from "react";
import Image from "../../Base/Image";
import "./DocumentGallery.scss"
export default DocumentGallery;
function DocumentThree(props){
    return(
        <div className="props">
            <div className="props__title">{props.title}</div>
            <div className="props__content">
            <div className="props__item">
                <img className="props__item-icon" src={props.icon} alt="" />
                <div className="props__item-text">
                    {props.text1}
                </div>
            </div>
            <div className="props__item">
            <img className="props__item-icon" src={props.icon} alt="" />
                <div className="props__item-text">
                    {props.text2}
                </div>
            </div>
            <div className="props__item">
            <img className="props__item-icon" src={props.icon} alt="" />
                <div className="props__item-text">
                    {props.text3}
                </div>
            </div>
            <div className="props__view wrraper__view">
            <div className="wrraper__view-text">View More</div>
                <img src={Image.arrowicon} alt="arrowicon" />
            </div>
            </div>
        </div>
    )
}
function DocumentFour(props){
    return(
        <div className="props">
            <div className="props__title">{props.title}</div>
            <div className="props__content">
            <div className="props__item">
                <img className="props__item-icon" src={props.icon} alt="" />
                <div className="props__item-text">
                    {props.text1}
                </div>
            </div>
            <div className="props__item">
            <img className="props__item-icon" src={props.icon} alt="" />
                <div className="props__item-text">
                    {props.text2}
                </div>
            </div>
            <div className="props__item">
            <img className="props__item-icon" src={props.icon} alt="" />
                <div className="props__item-text">
                    {props.text3}
                </div>
            </div>
            <div className="props__item">
            <img className="props__item-icon" src={props.icon} alt="" />
                <div className="props__item-text">
                    {props.text4}
                </div>
            </div>
            <div className="props__view wrraper__view">
            <div className="wrraper__view-text">View More</div>
                <img src={Image.arrowicon} alt="arrowicon" />
            </div>
            </div>
        </div>
    )
}
function DocumentGallery(){
    return(
        <div className="wrraper__document">
            <div className="wrraper__document-title">Document Gallery</div>
            <div className="wrraper__document">
            <div className="wrraper__content-document-left">
                <DocumentFour
                title="Policy"
                icon={Image.word}
                text1="Policy 1"
                text2="Policy 2"
                text3="Policy 3"
                text4="Policy 4"
                />
                <DocumentThree
                title="Corporate Template"
                icon={Image.word}
                text1="Template 1"
                text2="Template 2"
                text3="Template 3"
                />
                <DocumentThree
                title="Slider"
                icon={Image.powerpoint}
                text1="Template 1"
                text2="Template 2"
                text3="Template 3"
                />
            </div>
            <div className="wrraper__content-document-right">
            <DocumentFour
                title="SOP"
                icon={Image.word}
                text1="Demo Script"
                text2="App Introduction"
                text3="Index"
                text4="Tranning"
                />
                <DocumentFour
                title="Report"
                icon={Image.vsdx}
                text1="Report 1"
                text2="Report 1"
                text3="Report 1"
                text4="Report 1"
                />
            </div>
            </div>           
        </div>
    )
}