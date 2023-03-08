import { Add, Remove } from "@mui/icons-material";
import React from "react";
import { useState } from "react";
import { useLocation, useParams } from "react-router-dom";
import styled from "styled-components";
import Announcement from "../components/Announcement";
import Newsletter from "../components/Newsletter";
import Footer from "../components/Footer";
import Navbar from "../components/Navbar";
import { productsList } from "../data";
import { addProduct } from "../redux/cartRedux";
import { useDispatch } from "react-redux";

const Container = styled.div``;
const Wrapper = styled.div`
    padding: 50px;
    display: flex;
`;
const ImgContainer = styled.div`
    flex: 1;
`;
const Image = styled.img`
    width: 100%;
    height: 90vh;
    object-fit: contain;
`;
const InfoContainer = styled.div`
    flex: 1;
    padding: 0 50px;
`;
const Title = styled.h1`
    font-size: 40px;
`;
const Desc = styled.p`
    margin: 20px 0;
`;
const Price = styled.span`
    font-size: 40px;
    font-weight: 200;
`;

const FilterContainer = styled.div`
    width: 50%;
    margin: 30px 0;
    display: flex;
    justify-content: space-between;
`;
const Filter = styled.div`
    display: flex;
    align-items: center;
`;
const FilterTitle = styled.span`
    font-size: 20px;
    font-weight: 300;
`;
const FilterColor = styled.div`
    width: 30px;
    height: 30px;
    border-radius: 50%;
    background-color: ${(props) => props.color};
    margin: 0 5px;
    cursor: pointer;
`;
const FilterSize = styled.select`
    margin-left: 10px;
    padding: 10px;
    border: 2px solid #fa9494;
`;
const FilterSizeOption = styled.option``;

const AddContainer = styled.div`
    width: 50%;
    display: flex;
    align-items: center;
    justify-content: space-between;
`;
const AmountContainer = styled.div`
    display: flex;
    align-items: center;
    font-weight: 700;
`;
const AmountTitle = styled.div`
    font-size: 20px;
    font-weight: 300;
`;
const AmountChange = styled.div`
    display: flex;
    margin-left: 20px;
`;
const Icon = styled.div`
    width: 30px;
    height: 30px;
    border-radius: 10px;
    display: flex;
    align-items: center;
    justify-content: center;
    border: 1px solid #fa9494;
    color: white;
    background-color: #fa9494;
    cursor: pointer;
`;
const Amount = styled.span`
    width: 100px;
    height: 30px;
    border-radius: 10px;
    border: 1px solid #fa9494;
    display: flex;
    align-items: center;
    justify-content: center;
    margin: 0px 5px;
`;
const Button = styled.button`
    padding: 15px 30px;
    border: 2px solid #fa9494;
    background-color: white;
    cursor: pointer;
    font-weight: 500;
    margin-top: 50px;
    transition: 0.2s;
    &:hover {
        background-color: #fa9494;
        color: white;
    }
`;

const Product = () => {
    const [quantity, setQuantity] = useState(1);
    const [color, setColor] = useState("");
    const [size, setSize] = useState("");
    const dispatch = useDispatch();
    const { productId } = useParams();
    const thisProduct = productsList.find(
        (product) => product.id === productId
    );

    const handleChangeQuantity = (change) => {
        if (change === "descr") {
            quantity > 1 ? setQuantity(quantity - 1) : setQuantity(1);
        } else {
            setQuantity(quantity + 1);
        }
    };

    const handleClick = () => {
        dispatch(addProduct({ ...thisProduct, quantity, color, size }));
    };

    return (
        <Container>
            <Navbar />
            <Announcement />
            <Wrapper>
                <ImgContainer>
                    <Image src={thisProduct.img} />
                </ImgContainer>
                <InfoContainer>
                    <Title>{thisProduct.title}</Title>
                    <Desc>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                        Donec venenatis, dolor in finibus malesuada, lectus
                        ipsum porta nunc, at iaculis arcu nisi sed mauris. Nulla
                        fermentum vestibulum ex, eget tristique tortor pretium
                        ut. Curabitur elit justo, consequat id condimentum ac,
                        volutpat ornare.
                    </Desc>
                    <Price>${thisProduct.price}</Price>
                    <FilterContainer>
                        <Filter>
                            <FilterTitle>Color</FilterTitle>
                            {thisProduct.color?.map((colors) => (
                                <FilterColor
                                    color={colors}
                                    key={colors}
                                    onClick={() => setColor(colors)}
                                />
                            ))}
                        </Filter>
                        <Filter>
                            <FilterTitle>Size</FilterTitle>
                            <FilterSize
                                onChange={(e) => setSize(e.target.value)}
                            >
                                {thisProduct.size.map((size) => (
                                    <FilterSizeOption value={size} key={size}>
                                        {size}
                                    </FilterSizeOption>
                                ))}
                            </FilterSize>
                        </Filter>
                    </FilterContainer>
                    <AddContainer>
                        <AmountContainer>
                            <AmountTitle>Số lượng: </AmountTitle>
                            <AmountChange>
                                <Icon>
                                    <Remove
                                        onClick={() =>
                                            handleChangeQuantity("descr")
                                        }
                                    />
                                </Icon>
                                <Amount>{quantity}</Amount>
                                <Icon>
                                    <Add
                                        onClick={() =>
                                            handleChangeQuantity("incr")
                                        }
                                    />
                                </Icon>
                            </AmountChange>
                        </AmountContainer>
                    </AddContainer>
                    <Button onClick={() => handleClick()}>ADD TO CART</Button>
                </InfoContainer>
            </Wrapper>
            <Newsletter />
            <Footer />
        </Container>
    );
};

export default Product;
