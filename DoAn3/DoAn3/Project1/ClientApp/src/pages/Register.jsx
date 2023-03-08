import React, { useEffect } from "react";
import { useState } from "react";
import styled from "styled-components";
import { mobile } from "../responsive";
import { Link, useNavigate } from "react-router-dom";
import { createUserWithEmailAndPassword } from "firebase/auth";
import { auth } from "../firebase";

const Container = styled.div`
    width: 100vw;
    height: 100vh;
    background: linear-gradient(
            rgba(255, 255, 255, 0.5),
            rgba(255, 255, 255, 0.5)
        ),
        url("https://images.squarespace-cdn.com/content/v1/5c41bf032971148e7102d49c/1563715357387-YHP8NWGHGNE7JKBYMVU0/Always-Stylish-LisOShaughnessy-Personal-Stylist-London.jpg")
            center;
    background-size: cover;
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
`;
const Wrapper = styled.div`
    width: 40%;
    padding: 20px;
    background-color: white;
    ${mobile({ width: "75%" })}
`;
const Title = styled.h1`
    font-size: 24px;
`;
const Form = styled.form`
    display: flex;
    flex-wrap: wrap;
`;
const Input = styled.input`
    width: 100%;
    padding: 10px;
    border: 1px solid black;

    &:focus {
        outline: none;
    }
`;
const Agreement = styled.span`
    font-size: 12px;
    margin: 20px 0px;
`;
const Button = styled.button`
    width: 40%;
    border: 2px solid #fa9494;
    padding: 15px 20px;
    background-color: white;
    color: #fa9494;
    cursor: pointer;
    transition: 0.3s;

    &:hover {
        background-color: #fa9494;
        color: white;
    }
`;
const Import = styled.div`
    flex: 1;
    min-width: 40%;
    margin: 0px 10px 0px 0px;
    padding: 10px;
    display: flex;
    flex-direction: column;
`;
const Error = styled.span`
    font-size: 12px;
    color: red;
`;
const Notification = styled.div`
    display: flex;
    align-items: center;
    padding: 20px;
    font-size: 15px;
    font-weight: 700;
    background-color: #fa9494;
    margin-bottom: 50px;
    border-radius: 5px;
    transition: all 250ms linear 2s;
`;

const Login = styled.span`
    font-size: 12px;
    text-align: center;
    display: flex;
    align-items: center;
    margin-left: auto;
    text-decoration: underline;
    text-transform: uppercase;
    cursor: pointer;

    & a {
        color: black;
    }
`;

const Register = () => {
    const initialValues = {
        name: "",
        lastname: "",
        email: "",
        username: "",
        password: "",
        confirmPassword: "",
    };
    const [values, setValues] = useState(initialValues);
    const [formErrors, setFormErrors] = useState({});
    const [isSubmit, setIsSubmit] = useState(false);
    const [showingAlert, setShowingAlert] = useState(false);
    // const [data, setData] = useState([]);
    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();
        const { name, lastname, email, username, password, confirmPassword } =
            values;
        setFormErrors(validate(values));
        setIsSubmit(true);
        createUserWithEmailAndPassword(auth, email, password)
            .then((auth) => navigate("/login"))
            .catch((error) => console.log(error));
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setValues({ ...values, [name]: value });
        setFormErrors({ ...formErrors, [name]: null });
    };

    useEffect(() => {
        console.log(formErrors);
        if (Object.keys(formErrors).length === 0 && isSubmit) {
            setShowingAlert(true);
            setTimeout(() => {
                setShowingAlert(false);
            }, 3000);
        }
    }, [formErrors]);

    // useEffect(() => {
    //   if(isSubmit){}
    // })

    const validate = (value) => {
        const error = {};
        const regex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/i;
        if (!value.username) {
            error.username = "Please enter this information";
        }
        if (!value.name) {
            error.name = "Please enter this information";
        }
        if (!value.lastname) {
            error.lastname = "Please enter this information";
        }
        if (!value.email) {
            error.email = "Please enter this information";
        } else if (!regex.test(value.email)) {
            error.email = "This is not a valid email format";
        }
        if (!value.password) {
            error.password = "Please enter this information";
        } else if (value.password.length < 6) {
            error.password = "Password must be more than 6 characters";
        }
        if (!value.confirmPassword) {
            error.confirmPassword = "Please enter this information";
        } else if (value.confirmPassword !== value.password) {
            error.confirmPassword = "Please enter the correct password";
        }
        return error;
    };

    return (
        <Container>
            {Object.keys(formErrors).length === 0 &&
            isSubmit &&
            showingAlert ? (
                <Notification>Signed up Successfully</Notification>
            ) : null}
            <Wrapper>
                <Title>CREATE AN ACCOUNT</Title>
                <Form onSubmit={handleSubmit}>
                    <Import>
                        <Input
                            placeholder="name"
                            name="name"
                            onChange={handleChange}
                            value={values.name}
                        />
                        <Error>{formErrors.name}</Error>
                    </Import>
                    <Import>
                        <Input
                            placeholder="last name"
                            name="lastname"
                            value={values.lastname}
                            onChange={handleChange}
                        />
                        <Error>{formErrors.lastname}</Error>
                    </Import>
                    <Import>
                        <Input
                            placeholder="username"
                            type="text"
                            name="username"
                            value={values.username}
                            onChange={handleChange}
                        />
                        <Error>{formErrors.username}</Error>
                    </Import>
                    <Import>
                        <Input
                            placeholder="email"
                            name="email"
                            value={values.email}
                            onChange={handleChange}
                        />
                        <Error>{formErrors.email}</Error>
                    </Import>
                    <Import>
                        <Input
                            name="password"
                            placeholder="password"
                            type="password"
                            value={values.password}
                            onChange={handleChange}
                        />
                        <Error>{formErrors.password}</Error>
                    </Import>
                    <Import>
                        <Input
                            name="confirmPassword"
                            placeholder="confirm password"
                            type="password"
                            value={values.confirmPassword}
                            onChange={handleChange}
                        />
                        <Error>{formErrors.confirmPassword}</Error>
                    </Import>
                    <Agreement>
                        By creating an account, I consent to the processing of
                        my personal data in accordance with the{" "}
                        <b>PRIVACY POLICY</b>
                    </Agreement>
                    <Button>CREATE</Button>
                    <Login>
                        <Link to="/login">Have an account?</Link>
                    </Login>
                </Form>
            </Wrapper>
        </Container>
    );
};

export default Register;
