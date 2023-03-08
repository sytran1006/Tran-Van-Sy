import React from "react";
import styled from "styled-components";
import Footer from "../components/Footer";
import Navbar from "../components/Navbar";
import Newsletter from "../components/Newsletter";
import { CheckCircle } from "@mui/icons-material";

const Container = styled.div`
    padding: 100px 0;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
`;
const Icon = styled(CheckCircle)`
    font-size: 5rem !important;
`;
const Notify = styled.h1`
    color: #fa9494;
    margin-top: 10px;
`;
const Mess = styled.span`
    margin-top: 10px;
    font-size: 20px;
`;
const Success = () => {
    return (
        <>
            <Navbar />
            <Container>
                <Icon>
                    <CheckCircle />
                </Icon>

                <Notify>Successfully</Notify>
                <Mess>
                    Your order has been successfully placed! We will contact you
                    as soon as possible
                </Mess>
            </Container>
            <Newsletter />
            <Footer />
        </>
    );
};

export default Success;
