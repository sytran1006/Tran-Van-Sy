import React from "react";
import styled from "styled-components";
import { Search, ShoppingCartOutlined } from "@mui/icons-material";
import { mobile } from "../responsive";
import { Link } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux";
import { useContext } from "react";
import { AuthContext } from "../context/AuthContext";
import { useState, useEffect } from "react";
import { clearCart } from "../redux/cartRedux";
import { popularProducts, productsList } from "../data.js";

const Container = styled.div`
    height: 60px;
    ${mobile({ height: "50px;" })}
`;
const Wrapper = styled.div`
    padding: 10px 20px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    ${mobile({ padding: "10px 0px" })}
`;

const Left = styled.div`
    flex: 1;
    display: flex;
    align-items: center;
`;
const Logo = styled.h1`
    font-size: 28px;
    font-weight: 700;
    text-decoration: none;
    color: black;
    ${mobile({
        fontSize: "15px",
        width: "100%",
        textAlign: "center",
        marginLeft: "10px",
    })};
`;
const Center = styled.div`
    flex: 1;
    text-align: center;
    display: flex;
    align-items: center;
    justify-content: space-between;
    ${mobile({ flex: "1.5" })}
`;
const Menu = styled.div`
    display: flex;
    align-items: center;
    position: relative;

    & a {
        text-decoration: none;
        color: black;
    }
`;
const Right = styled.div`
    flex: 1;
    display: flex;
    align-items: center;
    justify-content: flex-end;
    ${mobile({ flex: 2, justifyContent: "center" })}
`;

const Language = styled.div`
    font-size: 14px;
    cursor: pointer;
    ${mobile({ display: "none" })}
`;

const SearchContainer = styled.div`
    border: 0.5px solid lightgray;
    display: flex;
    align-items: center;
    margin-left: 20px;
    padding: 5px;
`;

const Input = styled.input`
    border: none;
    ${mobile({ width: "50px" })}
    &:focus {
        outline: none;
        border: none;
    }
`;

const MenuItem = styled.div`
    min-width: 60px;
    text-align: center;
    border-radius: 10px;
    font-size: 14px;
    cursor: pointer;
    margin-left: 25px;
    padding: 10px 20px;
    background-color: #${(props) => props.bgrcolor};
    color: #${(props) => props.color};
    ${mobile({ fontSize: "12px", marginLeft: "10px" })}
`;
const MenuItemCart = styled.div`
    font-size: 14px;
    cursor: pointer;
    margin-left: 25px;
`;
const IconCart = styled.div`
    position: relative;
    width: 24px;
    height: 24px;
    & span {
        position: absolute;
        top: -6px;
        right: -5px;
        width: 18px;
        height: 18px;
        border-radius: 50%;
        background-color: #fa9494;
        color: white;
        display: flex;
        align-items: center;
        justify-content: center;
        text-align: center;
        font-size: 10px;
    }
`;
const SearchResult = styled.div`
    width: 400px;
    background-color: white;
    z-index: 99;
    position: absolute;
    top: 50px;
    left: 35px;
    // display: none;
`;
const ProductSearch = styled.div`
    padding: 10px;
    display: flex;
    min-height: 100px;
    &:hover {
        background-color: rgb(0, 0, 0, 0.05);
    }
`;
const ImgProductSearch = styled.div`
    max-width: 60px;
    margin-right: 20px;
`;
const Img = styled.img`
    width: 100%;
    height: 100%;
    object-fit: contain;
`;
const DetailProductSearch = styled.div`
    margin-top: 10px;
`;
const NameProductSearch = styled.h1`
    font-size: 20px;
    margin-bottom: 5px;
`;
const PriceProductSearch = styled.span`
    float: left;
`;
const Navbar = () => {
    const [valueSearch, setValueSearch] = useState("");
    const [showSearchResult, setShowSearchResult] = useState(false);
    const quantity = useSelector((state) => state.cart.quantity);
    const dispatchCart = useDispatch();
    const { currentUser, cart } = useContext(AuthContext);
    const { dispatch } = useContext(AuthContext);
    const handleLogout = () => {
        dispatch({
            type: "LOGOUT",
            payload: currentUser,
        });
        dispatchCart(clearCart());
    };

    const handleChange = (e) => {
        setValueSearch(e.target.value);
    };
    useEffect(() => {
        setShowSearchResult(true);
        if (valueSearch === "") {
            setShowSearchResult(false);
        }
    }, [valueSearch, showSearchResult]);
    return (
        <Container>
            <Wrapper>
                <Left>
                    <Link
                        to={`/`}
                        style={{
                            textDecoration: "none",
                        }}
                    >
                        <Logo> KAIS STORE </Logo>
                    </Link>
                </Left>
                <Center>
                    <Menu>
                        <Link to="/"> Home </Link>
                    </Menu>
                    <Menu>
                        <Link to="/products/All-Products"> Products </Link>
                    </Menu>
                    <Menu>
                        <Link to="/about"> About </Link>
                    </Menu>
                    <Menu>
                        <Language> EN </Language>
                        <SearchContainer>
                            <Input
                                value={valueSearch}
                                onChange={handleChange}
                                placeholder="Search..."
                            />
                            <Search
                                style={{
                                    color: "gray",
                                    fontSize: 16,
                                }}
                            />
                        </SearchContainer>
                        {showSearchResult ? (
                            <SearchResult>
                                {productsList
                                    .filter((product) =>
                                        product.title
                                            .toLowerCase()
                                            .includes(valueSearch)
                                    )
                                    .map((product) => (
                                        <Link to={`/product/${product.id}`}>
                                            <ProductSearch key={product.id}>
                                                <ImgProductSearch>
                                                    <Img
                                                        src={product.img}
                                                    ></Img>
                                                </ImgProductSearch>
                                                <DetailProductSearch>
                                                    <NameProductSearch>
                                                        {product.title}
                                                    </NameProductSearch>
                                                    <PriceProductSearch>
                                                        ${product.price}
                                                    </PriceProductSearch>
                                                </DetailProductSearch>
                                            </ProductSearch>
                                        </Link>
                                    ))}
                            </SearchResult>
                        ) : null}
                    </Menu>
                </Center>
                <Right>
                    {currentUser === null ? (
                        <Link
                            to={`../login`}
                            style={{
                                textDecoration: "none",
                                color: "black",
                            }}
                        >
                            <MenuItem color="fff" bgrcolor="fa9494">
                                Login
                            </MenuItem>
                        </Link>
                    ) : (
                        <Link
                            to={`../`}
                            style={{
                                textDecoration: "none",
                                color: "black",
                            }}
                        >
                            <MenuItem
                                color="fff"
                                bgrcolor="fa9494"
                                onClick={() => handleLogout()}
                            >
                                Log out
                            </MenuItem>
                        </Link>
                    )}
                    {currentUser === null ? (
                        <Link
                            to={`../register`}
                            style={{
                                textDecoration: "none",
                                color: "black",
                            }}
                        >
                            <MenuItem> Register </MenuItem>
                        </Link>
                    ) : null}
                    {currentUser === null ? (
                        <Link to="/login">
                            <MenuItemCart>
                                <IconCart>
                                    <ShoppingCartOutlined />
                                    <span> {quantity} </span>
                                </IconCart>
                            </MenuItemCart>
                        </Link>
                    ) : (
                        <Link to="/cart">
                            <MenuItemCart>
                                <IconCart>
                                    <ShoppingCartOutlined />
                                    <span> {quantity} </span>
                                </IconCart>
                            </MenuItemCart>
                        </Link>
                    )}
                </Right>
            </Wrapper>
        </Container>
    );
};

export default Navbar;
