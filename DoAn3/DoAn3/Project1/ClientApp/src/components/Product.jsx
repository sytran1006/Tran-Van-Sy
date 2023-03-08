import {
    FavoriteBorderOutlined,
    SearchOutlined,
    ShoppingCartOutlined,
    FavoriteIcon,
    FavoriteOutlined,
} from "@mui/icons-material";
import React from "react";
import styled from "styled-components";
import { Link } from "react-router-dom";

const Info = styled.div`
    opacity: 0;
    width: 100%;
    height: 100%;
    position: absolute;
    top: 0;
    left: 0;
    background-color: rgba(0, 0, 0, 0.2);
    z-index: 3;
    display: flex;
    align-items: center;
    justify-content: center;
    transition: all 0.5s ease;
    cursor: pointer;
    border-radius: 10px;
`;
const ProductItem = styled.div`
    width: 280px;
    height: 450px;
    border: 2px solid #ffdede;
    margin-bottom: 20px;
    border-radius: 10px;
    &:hover ${Info} {
        opacity: 1;
    }
`;
const Container = styled.div`
    flex: 1;

    width: 100%;
    height: 80%;
    display: flex;
    align-items: center;
    justify-content: center;
    background-color: #ffdede;
    position: relative;
    border-radius: 10px;
`;
const Circle = styled.div`
    width: 250px;
    height: 250px;
    border-radius: 50%;
    background-color: white;
    position: absolute;
`;
const Image = styled.img`
    height: 50%;
    z-index: 2;
`;

const Icon = styled.div`
    width: 40px;
    height: 40px;
    border-radius: 50%;
    background-color: white;
    margin: 0 10px;
    display: flex;
    align-items: center;
    justify-content: center;
    transition: all 0.2s ease;

    a {
        color: black;
        width: 100%;
        height: 100%;
        border-radius: 50%;
        display: flex;
        align-items: center;
        justify-content: center;
    }

    &:hover {
        background-color: #ffc7c7;
        color: white;
        transform: scale(1.1);
    }

    &:hover a {
        background-color: #ffc7c7;
        color: white;
        transform: scale(1.1);
    }
`;
const ProductName = styled.h1`
    text-align: center;
    margin-top: 10px;
    font-size: 20px;
`;
const ProductPrice = styled.span`
    padding: 5px 15px;
    background-color: #fa9494;
    color: white;
    float: right;
    margin-right: 10px;
    margin-top: 15px;
`;

const Product = ({ item }) => {
    return (
        <ProductItem>
            <Container>
                <Circle />
                <Image src={item.img} />
                <Info>
                    <Icon>
                        <Link
                            to={`/product/${item.id}`}
                            style={{ textDecoration: "none" }}
                        >
                            <SearchOutlined />
                        </Link>
                    </Icon>
                </Info>
            </Container>
            <ProductName>{item.title}</ProductName>
            <ProductPrice>${item.price}</ProductPrice>
        </ProductItem>
    );
};

export default Product;
