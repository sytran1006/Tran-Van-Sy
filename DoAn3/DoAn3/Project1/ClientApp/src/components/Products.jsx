import React, { useEffect } from "react";
import styled from "styled-components";
import { popularProducts, productsList } from "../data.js";
import Product from "./Product";
import { useState } from "react";
import { useLocation } from "react-router-dom";
import Pagination from "./Pagination.jsx";

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
const Products = ({ cat, filters, sort }) => {
    const [products, setProducts] = useState([]);
    const [cateProducts, setCateProducts] = useState([]);
    const [filteredProducts, setFilteredProducts] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [postsPerPage, setPostsPerPage] = useState(4);
    const [totalPosts, setTotalPosts] = useState([]);

    // let pages = [];
    const lastPostIndex = currentPage * postsPerPage;
    const firstPostIndex = lastPostIndex - postsPerPage;
    const currentPost = productsList.slice(firstPostIndex, lastPostIndex);
    useEffect(() => {
        if (cat === "Shirts") {
            const arr1 = productsList.filter(
                (pro) => pro.category === "Shirts"
            );
            setTotalPosts(arr1);
        } else if (cat === "Trousers") {
            const l2 = productsList.filter(
                (pro) => pro.category === "Trousers"
            );

            setTotalPosts(l2);
        } else if (cat === "Accessory") {
            const l3 = productsList.filter(
                (pro) => pro.category === "Accessory"
            );

            setTotalPosts(l3);
        } else {
            const l4 = productsList;
            setTotalPosts(l4);
        }
    }, [cat]);

    useEffect(() => {
        cat === "Shirts"
            ? setFilteredProducts(
                  productsList
                      .filter((pro) => pro.category === "Shirts")
                      .slice(firstPostIndex, lastPostIndex)
                      .filter((item) =>
                          Object.entries(filters).every(([key, value]) => {
                              //   setTotalPosts(item[key]);
                              return item[key].includes(value);
                          })
                      )
              )
            : cat === "Trousers"
            ? setFilteredProducts(
                  productsList
                      .filter((pro) => pro.category === "Trousers")
                      .slice(firstPostIndex, lastPostIndex)
                      .filter((item) =>
                          Object.entries(filters).every(([key, value]) => {
                              //   setTotalPosts(item[key]);
                              return item[key].includes(value);
                          })
                      )
              )
            : cat === "Accessory"
            ? setFilteredProducts(
                  productsList
                      .filter((pro) => pro.category === "Accessory")
                      .slice(firstPostIndex, lastPostIndex)
                      .filter((item) =>
                          Object.entries(filters).every(([key, value]) => {
                              //   setTotalPosts(item[key]);
                              return item[key].includes(value);
                          })
                      )
              )
            : setFilteredProducts(
                  currentPost.filter((item) =>
                      Object.entries(filters).every(([key, value]) => {
                          //   console.log(item[key].includes(value));
                          //   setTotalPosts(item[key].includes(value));
                          return item[key].includes(value);
                      })
                  )
              );
    }, [productsList, cat, filters, firstPostIndex, lastPostIndex]);

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

    return (
        <Container>
            <ContainerProducts>
                {cat
                    ? filteredProducts.map((item) => (
                          <Product item={item} key={item.id} />
                      ))
                    : currentPost.map((item) => {
                          return <Product item={item} key={item.id} />;
                      })}
            </ContainerProducts>
            <Pagination
                totalPosts={totalPosts.length}
                postsPerPage={postsPerPage}
                currentPage={currentPage}
                setCurrentPage={setCurrentPage}
            />
        </Container>
    );
};

export default Products;
