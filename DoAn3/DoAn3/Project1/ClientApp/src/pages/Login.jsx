import { useRef, useState, useEffect, useContext } from "react";
import styled from "styled-components";
import { mobile } from "../responsive";
import { useNavigate } from "react-router-dom";
import { signInWithEmailAndPassword } from "firebase/auth";
import { auth } from "../firebase";
import { AuthContext } from "../context/AuthContext";

const Container = styled.div`
    width: 100vw;
    height: 100vh;
    background: linear-gradient(
            rgba(255, 255, 255, 0.5),
            rgba(255, 255, 255, 0.5)
        ),
        url("https://cdn.phunuvagiadinh.vn/ctvseo_ladang/stylist-la-gi-tim-hieu-chi-tiet-cong-viec-cua-mot-stylist2466.jpg")
            center;
    background-size: cover;
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
`;

const Wrapper = styled.div`
    width: 25%;
    padding: 20px;
    background-color: white;
    ${mobile({ width: "75%" })}
`;

const Title = styled.h1`
    font-size: 24px;
    padding: 15px 0;
    text-align: center;
    ${mobile({ margin: "15px 0" })}
`;

const Form = styled.form`
    display: flex;
    flex-direction: column;
`;

const Input = styled.input`
    flex: 1;
    min-width: 40%;
    margin: 10px 0;
    padding: 10px;
    &:focus {
        outline: none;
    }
`;

const Button = styled.button`
    width: 40%;
    border: 2px solid #fa9494;
    padding: 10px 20px;
    background-color: #fa9494;
    color: white;
    cursor: pointer;
    margin-bottom: 10px;
    margin-top: 20px;
    transition: 0.3s;
`;

const Link = styled.a`
    margin: 5px 0px;
    font-size: 12px;
    text-decoration: underline;
    cursor: pointer;
    color: black;
`;

const Import = styled.div`
    flex: 1;
    min-width: 40%;
    margin: 0px 10px 0px 0px;
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

const Login = () => {
    const initialValues = {
        email: "",
        password: "",
    };
    const [values, setValues] = useState(initialValues);
    const [formErrors, setFormErrors] = useState({});
    const [isSubmit, setIsSubmit] = useState(false);
    const navigate = useNavigate();
    const [error, setError] = useState(false);
    // const [showingAlert, setShowingAlert] = useState(false);

    const { dispatch } = useContext(AuthContext);

    const handleSubmit = (e) => {
        e.preventDefault();
        const { email, password } = values;
        setFormErrors(validate(values));
        setIsSubmit(true);
        signInWithEmailAndPassword(auth, email, password)
            .then((userCredential) => {
                const user = userCredential.user;
                dispatch({ type: "LOGIN", payload: user });
            })
            .catch((error) => {
                setError(true);
            });
    };
    const handleChange = (e) => {
        const { name, value } = e.target;
        setValues({ ...values, [name]: value });
        setFormErrors({ ...formErrors, [name]: null });
    };

    const validate = (value) => {
        const error = {};
        if (!value.email) {
            error.email = "Please enter this information";
        }
        if (!value.password) {
            error.password = "Please enter this information";
        } else if (value.password.length < 6) {
            error.password = "Password must be more than 6 characters";
        }
        return error;
    };
    useEffect(() => {
        if (error === true) {
            setTimeout(() => {
                setError(false);
            }, 5000);
        }
    }, [error]);
    return (
        <Container>
            {error && <Notification>Error. Login Failed!!!</Notification>}
            <Wrapper>
                <Title>SIGN IN</Title>
                <Form onSubmit={handleSubmit}>
                    <Import>
                        <Input
                            placeholder="email"
                            type="text"
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
                    <Button>LOGIN</Button>
                    <Link href="/">RETURN HOME PAGE</Link>
                    <Link href="/register">CREATE A NEW ACCOUNT</Link>
                </Form>
            </Wrapper>
        </Container>
    );
};

export default Login;
