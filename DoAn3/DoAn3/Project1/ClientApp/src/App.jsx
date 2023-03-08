import Cart from "./pages/Cart";
import Home from "./pages/Home";
import Login from "./pages/Login";
import Product from "./pages/Product";
import ProductList from "./pages/ProductList";
import Register from "./pages/Register";

import { productsList } from "./data";
import {
    BrowserRouter as Router,
    Routes,
    Route,
    Navigate,
} from "react-router-dom";
import About from "./pages/About";
import { useContext } from "react";
import { AuthContext } from "./context/AuthContext";
import Success from "./pages/Success";

function App() {
    const { currentUser } = useContext(AuthContext);
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/products/:category" element={<ProductList />} />

                <Route
                    path="/product/:productId"
                    // render={({ match }) => (
                    //   <Product
                    //     product={productsList.find(
                    //       (product) => String(product.id) === match.params.id
                    //     )}
                    //   />
                    // )}
                    element={<Product />}
                />
                <Route path="/about" element={<About />} />
                <Route path="/cart" element={<Cart />} />
                <Route path="/success" element={<Success />} />

                {currentUser ? (
                    <Route
                        path="/login"
                        element={<Navigate replace to="/" />}
                    />
                ) : (
                    <Route path="/login" element={<Login />} />
                )}
                {currentUser ? (
                    <Route
                        path="/register"
                        element={<Navigate replace to="/" />}
                    />
                ) : (
                    <Route path="/register" element={<Register />} />
                )}
            </Routes>
        </Router>
    );
}

export default App;
