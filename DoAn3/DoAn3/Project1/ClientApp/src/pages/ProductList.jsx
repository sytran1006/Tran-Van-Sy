import React from "react";
import { useLocation } from "react-router-dom";
import { useState } from "react";
import styled from "styled-components";
import Announcement from "../components/Announcement";
import Footer from "../components/Footer";
import Navbar from "../components/Navbar";
import Newsletter from "../components/Newsletter";
import Products from "../components/Products";
import { mobile } from "../responsive";

const Container = styled.div``;
const Title = styled.h1`
    margin: 20px;
`;
const FilterContainer = styled.div`
    display: flex;
    justify-content: space-between;
    align-item: center;
`;
const Filter = styled.div`
    margin: 20px;
`;
const FilterText = styled.span`
    font-size: 20px;
    font-weight: 600;
    margin-right: 20px;
`;
const Select = styled.select`
    padding: 10px;
    margin-right: 20px;
`;
const Option = styled.option``;

const ProductList = () => {
    const location = useLocation();
    const cat = location.pathname.split("/")[2];
    const [sort, setSort] = useState("newest");
    // console.log(cat);
    const [filters, setFilters] = useState({});
    const handleFilter = (e) => {
        const value = e.target.value;
        setFilters({
            ...filters,
            [e.target.name]: value,
        });
        if (value === "Color" && e.target.name === "color") {
            const { color, ...notColor } = filters;
            setFilters(notColor);
        }
        if (value === "Size" && e.target.name === "size") {
            const { size, ...notSize } = filters;
            setFilters(notSize);
        }
    };

    console.log(filters);
    return (
        <Container>
            <Navbar />
            <Announcement />
            <Title>{cat}</Title>
            <FilterContainer>
                <Filter>
                    <FilterText>Filter Products:</FilterText>
                    <Select name="color" onChange={handleFilter}>
                        <Option value="Color">Color</Option>
                        <Option value="darkgray">darkgray</Option>
                        <Option value="red">red</Option>
                        <Option value="yellow">yellow</Option>
                        <Option value="black">black</Option>
                        <Option value="gray">gray</Option>
                        <Option value="blue">blue</Option>
                    </Select>
                    <Select name="size" onChange={handleFilter}>
                        <Option value="Size">Size</Option>
                        <Option value="S">S</Option>
                        <Option value="M">M</Option>
                        <Option value="L">L</Option>
                        <Option value="XL">XL</Option>
                        <Option value="XXL">XXL</Option>
                    </Select>
                </Filter>
                <Filter>
                    <FilterText>Sort Products:</FilterText>
                    <Select onChange={(e) => setSort(e.target.value)}>
                        <Option value="newest">Newest</Option>
                        <Option value="lowest">Price (Lowest)</Option>
                        <Option value="highest">Price (Highest)</Option>
                    </Select>
                </Filter>
            </FilterContainer>
            <Products cat={cat} filters={filters} sort={sort} />
            <Newsletter />
            <Footer />
        </Container>
    );
};

export default ProductList;
