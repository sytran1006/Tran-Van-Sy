import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import { Provider } from "react-redux";
import { store, persistor } from "./redux/store";
import { AuthContextProvider } from "./context/AuthContext";
import { PersistGate } from "redux-persist/integration/react";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
    <Provider store={store}>
        <AuthContextProvider>
            <PersistGate loading={null} persistor={persistor}>
                <App />
            </PersistGate>
        </AuthContextProvider>
    </Provider>
);
