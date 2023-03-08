import React from "react";
import styled from "styled-components";
import Announcement from "../components/Announcement";
import Categories from "../components/Categories";
import Footer from "../components/Footer";
import Navbar from "../components/Navbar";
import Newsletter from "../components/Newsletter";
import Products from "../components/Products";
import ProductsHome from "../components/ProductsHome";
import Slider from "../components/Slider";
import { mobile } from "../responsive";

const Title = styled.h1`
    font-size: 40px;
    text-align: center;
    ${mobile({ marginTop: "20px" })}
`;

const Underline = styled.div`
    width: 100px;
    height: 3px;
    background-color: black;
    margin: auto;
`;

const Home = () => {
    return (
        <div>
            <Announcement />
            <Navbar />
            <Slider />
            <Categories />
            <Title>
                Featured Products
                <Underline></Underline>
            </Title>
            <ProductsHome />
            <Newsletter />
            <Footer />
        </div>
    );
};

export default Home;
