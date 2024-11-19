import { createBrowserRouter } from "react-router-dom";
import Login from "../pages/Login";
import Layout from "../components/Layout";
import Home from "../pages/Home";
import Product from "../pages/products/Product";
import Create from "../pages/products/Create";
import ShoppingCart from "../pages/ShoppingCart";
import Order from "../pages/Order";

const productRoute = {
	path: "/products",
	children: [
		{
			path: "/products",
			element: <Product/>
		},
		{
			path: "/products/create",
			element: <Create/>
		}
	]
}

const routes = [	
	{
		path: "/login",
		element: <Login/>
	},
	{
		path: "/",
		element: <Layout/>,		
		children: [
			{
				path: "/",
				element: <Home/>
			},
			productRoute,
			{
				path: "/shopping-carts",
				element: <ShoppingCart/>
			},
			{
				path: "/orders",
				element: <Order/>
			}
		]
	}
];

export const router = createBrowserRouter(routes,{
	future: {
		v7_partialHydration: true,
		v7_skipActionErrorRevalidation: true,
		v7_normalizeFormMethod: true,
		v7_fetcherPersist: true,
		v7_relativeSplatPath: true
	}	
})