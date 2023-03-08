import { Send } from "@mui/icons-material";
import React from "react";
import styled from "styled-components";
import { mobile } from "../responsive";
import { useState } from "react";

const Container = styled.div`
    height: 60vh;
    background-color: #fcf5f5;
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
`;
const Title = styled.h1`
    font-size: 70px;
    margin-bottom: 20px;
    ${mobile({ fontSize: "50px" })}
`;
const Desc = styled.div`
    font-size: 24px;
    font-weight: 300;
    margin-bottom: 20px;
    ${mobile({ textAlign: "center", fontSize: "18px" })}
`;
const InputContainer = styled.div`
    width: 50%;
    height: 40px;
    background-color: white;
    display: flex;
    justify-content: space-between;
    align-item: center;
    ${mobile({ width: "80%" })}
`;
const Notify = styled.h1`
    color: #fa9494;
`;
const Input = styled.input`
    border: none;
    padding-left: 20px;
    flex: 8;

    &:focus {
        border: none;
        outline: none;
    }
`;
const Button = styled.button`
    flex: 1;
    border: none;
    background-color: #fa9494;
    color: white;
    transition: 0.3s;
    cursor: pointer;

    &:hover {
        transform: scale(1.1);
    }
`;

const Error = styled.span`
    color: red;
    font-size: 14px;
    margin-top: 10px;
    text-align: left;
`;

const Newsletter = () => {
    const [email, setEmail] = useState("");
    const [check, setCheck] = useState(false);
    const [error, setError] = useState(false);
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/i;
    const handleClick = () => {
        if (!regex.test(email)) {
            setError(true);
        } else {
            setCheck(true);
            setError(false);
        }
    };
    const handleChange = (e) => {
        setEmail(e.target.value);
    };
    return (
        <Container>
            <Title>NEWSLETTER</Title>
            <Desc>Get timely updates from your favorite products.</Desc>
            {check ? (
                <Notify>We will send you information soon</Notify>
            ) : (
                <InputContainer>
                    <Input
                        placeholder="Your email"
                        className="email"
                        name="email"
                        value={email}
                        onChange={handleChange}
                    />
                    <Button onClick={() => handleClick()}>
                        <Send />
                    </Button>
                </InputContainer>
            )}
            {error ? <Error>This is not a valid email format</Error> : null}
        </Container>
    );
};

export default Newsletter;
