import React from "react";
import styled from "styled-components";
import Footer from "../components/Footer";
import Navbar from "../components/Navbar";
import Newsletter from "../components/Newsletter";

const Container = styled.div``;
const Content = styled.div`
  display: flex;
  justify-content: space-between;
`;
const Left = styled.div`
  flex: 1;
  padding: 150px 50px;
`;
const Right = styled.div`
  flex: 1;
  padding: 100px 150px 50px 50px;
`;
const Title = styled.h1`
  font-size: 50px;
`;
const Underline = styled.div`
  width: 100px;
  height: 5px;
  background-color: #fa9494;
`;
const Desc = styled.p`
  margin-top: 50px;
  letter-spacing: 1px;
  line-height: 1.6;
`;
const Img = styled.img`
  width: 100%;
  height: 100%;
  object-fit: contain;
`;

const About = () => {
  return (
    <Container>
      <Navbar />
      <Content>
        <Left>
          <Img src="https://www.pngarts.com/files/1/Fashion-PNG-Photo.png" />
        </Left>
        <Right>
          <Title>
            Our Story
            <Underline></Underline>
          </Title>
          <Desc>
            Lorem ipsum, dolor sit amet consectetur adipisicing elit. Fugiat
            accusantium sapiente tempora sed dolore esse deserunt eaque
            excepturi, delectus error accusamus vel eligendi, omnis beatae.
            Quisquam, dicta. Eos quod quisquam esse recusandae vitae neque
            dolore, obcaecati incidunt sequi blanditiis est exercitationem
            molestiae delectus saepe odio eligendi modi porro eaque in libero
            minus unde sapiente consectetur architecto. Ullam rerum, nemo iste
            ex, eaque perspiciatis nisi, eum totam velit saepe sed quos
            similique amet. Ex, voluptate accusamus nesciunt totam vitae esse
            iste.
          </Desc>
        </Right>
      </Content>
      <Newsletter />
      <Footer />
    </Container>
  );
};

export default About;
