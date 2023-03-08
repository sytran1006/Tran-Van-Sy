import React, { useEffect } from "react";
import styled from "styled-components";
import { popularProducts, productsList } from "../data.js";
import Product from "./Product";
import { useState } from "react";
import { useLocation } from "react-router-dom";

const Container = styled.div`
    padding: 50px 0;
    background-color: white;
`;
const ContainerProducts = styled.div`
    margin-left: 70px;
    display: grid;
    grid-template-columns: 25% 25% 25% 25%;
    grid-gap: 20px 0px;
`;
const ProductsHome = ({ cat, filters, sort }) => {
    const [products, setProducts] = useState([]);
    const [filteredProducts, setFilteredProducts] = useState([]);
    const shirtProducts = [];
    const trouserProducts = [];
    const accessoryProducts = [];
    productsList.forEach((item) => {
        if (item.category == "Shirts") {
            shirtProducts.push(item);
        } else if (item.category === "Trousers") {
            trouserProducts.push(item);
        } else if (item.category === "Accessory") {
            accessoryProducts.push(item);
        }
    });
    useEffect(() => {
        cat &&
            setFilteredProducts(
                productsList.filter((item) =>
                    Object.entries(filters).every(([key, value]) =>
                        item[key].includes(value)
                    )
                )
            );
    }, [productsList, cat, filters]);
    // useEffect(() => {
    //     cat &&
    //         setFilteredProducts(
    //             shirtProducts.filter((item) =>
    //                 Object.entries(filters).every(([key, value]) =>
    //                     item[key].includes(value)
    //                 )
    //             )
    //         );
    // }, [shirtProducts, cat, filters]);
    // useEffect(() => {
    //     cat &&
    //         setFilteredProducts(
    //             trouserProducts.filter((item) =>
    //                 Object.entries(filters).every(([key, value]) =>
    //                     item[key].includes(value)
    //                 )
    //             )
    //         );
    // }, [trouserProducts, cat, filters]);
    // useEffect(() => {
    //     cat &&
    //         setFilteredProducts(
    //             accessoryProducts.filter((item) =>
    //                 Object.entries(filters).every(([key, value]) =>
    //                     item[key].includes(value)
    //                 )
    //             )
    //         );
    // }, [accessoryProducts, cat, filters]);
    useEffect(() => {
        if (sort === "newest") {
            setFilteredProducts((prev) =>
                [...prev].sort((a, b) => a.createdAt - b.createdAt)
            );
        } else if (sort === "lowest") {
            setFilteredProducts((prev) =>
                [...prev].sort((a, b) => a.price - b.price)
            );
        } else {
            setFilteredProducts((prev) =>
                [...prev].sort((a, b) => b.price - a.price)
            );
        }
    }, [sort]);
    const listItem = [];
    const arr = [];
    for (var i = 0; i < productsList.length; i++) {
        arr.push({ id: i + 1, like: false });
    }

    // console.log(accessoryProducts);
    return (
        <Container>
            <ContainerProducts>
                {productsList.slice(0, 8).map((item) => {
                    listItem.push(item);
                    return <Product item={item} key={item.id} listItem={arr} />;
                })}
            </ContainerProducts>
        </Container>
    );
};

export default ProductsHome;
