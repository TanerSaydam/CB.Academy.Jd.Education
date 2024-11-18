import Layout from "../components/Layout";
import Home from "../pages/Home";
import Product from "../pages/Product";
import Login from "../pages/Login";
import { createBrowserRouter } from "react-router-dom";

export const router = createBrowserRouter([
    {
        path: "/login",
        element: <Login />
    },
    {
        path: "/",
        element: <Layout />,
        children: [
            {
                path: "/",
                element: <Home/>
            },
            {
                path: "/products",
                element: <Product />
            }
        ]
    }
]);