import { Add, Remove, Delete } from "@mui/icons-material";
import { useDispatch, useSelector } from "react-redux";
import styled from "styled-components";
import Announcement from "../components/Announcement";
import Footer from "../components/Footer";
import Navbar from "../components/Navbar";
import { mobile } from "../responsive";
import { Link, Navigate, useNavigate } from "react-router-dom";
import {
    clearCart,
    deleteProduct,
    increaseProduct,
    decreaseProduct,
    calculateTotals,
} from "../redux/cartRedux";
import { useEffect, useState } from "react";
import StripeCheckout from "react-stripe-checkout";
const KEY = process.env.REACT_APP_STRIPE;

const Container = styled.div``;

const Wrapper = styled.div`
    padding: 20px;
    ${mobile({ padding: "10px" })}
`;

const Title = styled.h1`
    font-weight: 300;
    text-align: center;
`;

const Top = styled.div`
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 20px;
`;

const BackToShopping = styled.button`
    padding: 10px;
    font-weight: 600;
    cursor: pointer;
    border: 2px solid #fa9494;
    background-color: white;
`;

const TopButton = styled.button`
    padding: 10px;
    font-weight: 600;
    cursor: pointer;
    border: none;
    background-color: #fa9494;
    color: white;
`;

const TopTexts = styled.div`
    ${mobile({ display: "none" })}
`;
const TopText = styled.span`
    text-decoration: underline;
    cursor: pointer;
    margin: 0px 10px;
    color: #000;
`;

const Bottom = styled.div`
    display: flex;
    justify-content: space-between;
    ${mobile({ flexDirection: "column" })}
`;

const Info = styled.div`
    flex: 3;
`;

const Product = styled.div`
    position: relative;
    display: flex;
    justify-content: space-between;
    border-bottom: 1px solid #eee;
    ${mobile({ flexDirection: "column" })};
`;

const DeleteItem = styled.div`
    position: absolute;
    right: 0;
    bottom: 0;
    padding: 10px;
    cursor: pointer;
`;

const ProductDetail = styled.div`
    flex: 2;
    display: flex;
`;

const Image = styled.img`
    width: 200px;
    height: 200px;
    padding: 20px 0;
    object-fit: contain;
`;

const Details = styled.div`
    padding: 20px;
    display: flex;
    flex-direction: column;
    justify-content: space-around;
`;

const ProductName = styled.span``;

const ProductId = styled.span``;

const ProductColor = styled.div`
    width: 20px;
    height: 20px;
    border-radius: 50%;
    background-color: ${(props) => props.color};
`;

const ProductSize = styled.span``;

const PriceDetail = styled.div`
    flex: 1;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
`;

const ProductAmountContainer = styled.div`
    display: flex;
    align-items: center;
    margin-bottom: 20px;
`;

const ProductAmount = styled.div`
    font-size: 24px;
    margin: 5px;
    ${mobile({ margin: "5px 15px" })}
`;

const ProductPrice = styled.div`
    font-size: 30px;
    font-weight: 200;
    ${mobile({ marginBottom: "20px" })}
`;

const Hr = styled.hr`
    background-color: #eee;
    border: none;
    height: 1px;
`;
const Clear = styled.div`
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    margin-top: 20px;
`;
const ClearButton = styled.button`
    background-color: #fa9494;
    color: #fff;
    border: none;
    padding: 15px 30px;
    font-weight: bold;
    cursor: pointer;
`;
const Summary = styled.div`
    flex: 1;
    border: 0.5px solid lightgray;
    border-radius: 10px;
    padding: 20px;
    height: 50vh;
`;

const SummaryTitle = styled.h1`
    font-weight: 200;
`;

const SummaryItem = styled.div`
    margin: 30px 0px;
    display: flex;
    justify-content: space-between;
    font-weight: ${(props) => props.type === "total" && "500"};
    font-size: ${(props) => props.type === "total" && "24px"};
`;

const SummaryItemText = styled.span``;

const SummaryItemPrice = styled.span``;

const Button = styled.button`
    width: 100%;
    padding: 10px;
    background-color: #fa9494;
    color: white;
    font-weight: 600;
    border: none;
`;

const Cart = () => {
    const dispatch = useDispatch();
    const cart = useSelector((state) => state.cart);
    const quantity = useSelector((state) => state.cart.quantity);
    const [stripeToken, setStripeToken] = useState(null);
    useEffect(() => {
        dispatch(calculateTotals());
    }, [cart.products]);
    const navigate = useNavigate();
    const onToken = (token) => {
        setStripeToken(token);
    };
    useEffect(() => {
        stripeToken &&
            cart.total >= 1 &&
            dispatch(clearCart()) &&
            navigate("/success");
    }, [stripeToken, cart.total]);
    return (
        <Container>
            <Navbar />
            <Announcement />
            <Wrapper>
                <Title>YOUR BAG</Title>
                <Top>
                    <Link to="/products/All-Products">
                        <BackToShopping>CONTINUE SHOPPING</BackToShopping>
                    </Link>
                    <TopTexts>
                        <TopText>Shopping Bag({quantity})</TopText>
                    </TopTexts>
                    <TopButton type="filled">CHECKOUT NOW</TopButton>
                </Top>
                <Bottom>
                    <Info>
                        {cart.products.map((product, index) => {
                            const { id, color } = product;
                            return (
                                <Product key={index}>
                                    <ProductDetail>
                                        <Image src={product.img} />
                                        <Details>
                                            <ProductName>
                                                <b>Product:</b> {product.title}
                                            </ProductName>
                                            <ProductId>
                                                <b>ID:</b> {product.id}
                                            </ProductId>
                                            <ProductColor
                                                color={product.color}
                                            />
                                            <ProductSize>
                                                <b>Size:</b> {product.size}
                                            </ProductSize>
                                        </Details>
                                    </ProductDetail>
                                    <PriceDetail>
                                        <ProductAmountContainer>
                                            <Add
                                                onClick={() =>
                                                    dispatch(
                                                        increaseProduct(
                                                            product.id
                                                        )
                                                    )
                                                }
                                            />
                                            <ProductAmount>
                                                {product.quantity}
                                            </ProductAmount>
                                            <Remove
                                                onClick={() => {
                                                    if (
                                                        product.quantity === 1
                                                    ) {
                                                        dispatch(
                                                            deleteProduct({
                                                                id,
                                                                color,
                                                            })
                                                        );
                                                    }
                                                    dispatch(
                                                        decreaseProduct(
                                                            product.id
                                                        )
                                                    );
                                                }}
                                            />
                                        </ProductAmountContainer>
                                        <ProductPrice>
                                            ${product.price * product.quantity}
                                        </ProductPrice>
                                    </PriceDetail>
                                    <DeleteItem
                                        onClick={() =>
                                            dispatch(
                                                deleteProduct({ id, color })
                                            )
                                        }
                                    >
                                        <Delete />
                                    </DeleteItem>
                                </Product>
                            );
                        })}
                        <Hr />
                        <Clear>
                            <ClearButton
                                onClick={() => {
                                    dispatch(clearCart());
                                }}
                            >
                                DELETE ALL
                            </ClearButton>
                        </Clear>
                    </Info>
                    <Summary>
                        <SummaryTitle>ORDER SUMMARY</SummaryTitle>
                        <SummaryItem>
                            <SummaryItemText>Subtotal</SummaryItemText>
                            <SummaryItemPrice>${cart.total}</SummaryItemPrice>
                        </SummaryItem>
                        <SummaryItem>
                            <SummaryItemText>
                                Estimated Shipping
                            </SummaryItemText>
                            <SummaryItemPrice>$ 5.90</SummaryItemPrice>
                        </SummaryItem>
                        <SummaryItem>
                            <SummaryItemText>Shipping Discount</SummaryItemText>
                            <SummaryItemPrice>$ -5.90</SummaryItemPrice>
                        </SummaryItem>
                        <SummaryItem type="total">
                            <SummaryItemText>Total</SummaryItemText>
                            <SummaryItemPrice>${cart.total}</SummaryItemPrice>
                        </SummaryItem>
                        <StripeCheckout
                            name="KaiS Store"
                            image="https://media.cdnandroid.com/item_images/1141766/imagen-logo-maker-create-logos-and-icon-design-creator-0ori.jpg"
                            billingAddress
                            shippingAddress
                            description={`Your total is $${cart.total}`}
                            amount={cart.total * 100}
                            token={onToken}
                            stripeKey="pk_test_51ML052JPAY0aynYcR9ZHS8JHT7HOn8RagAMgpGupE1si1PINUGo8xUjCi3YteuBhGPrLz3xtl3MjkYPr0xda8KGm006s4Wd54s"
                        >
                            <Button>CHECKOUT NOW</Button>
                        </StripeCheckout>
                    </Summary>
                </Bottom>
            </Wrapper>
            <Footer />
        </Container>
    );
};

export default Cart;
