// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAuth } from "firebase/auth";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
const firebaseConfig = {
    apiKey: process.env.REACT_APP_FIREBASE_KEY,
    authDomain: "ecommerce-74b29.firebaseapp.com",
    projectId: "ecommerce-74b29",
    storageBucket: "ecommerce-74b29.appspot.com",
    messagingSenderId: "385510141264",
    appId: "1:385510141264:web:8b0632625981e513769055",
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const auth = getAuth();

export { auth };
