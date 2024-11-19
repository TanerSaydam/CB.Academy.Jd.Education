import { createContext, useEffect, useState } from "react";
import { RouterProvider } from "react-router-dom";
import {router} from "../utilities/router";
import axios from "axios";
import { api } from "../constants";

export const CountContext = createContext(0);

function App(){
    const [count, setCount]=useState(0);

    async function getShoppingCount() {
        try {
            var result = await axios.get(`${api}/api/ShoppingCarts/count`);

            setCount(result.data.count);
        } catch (error) {
            
        }
    }

    useEffect(()=>{
       getShoppingCount();
    },[]);

    return(
        <>
        <CountContext.Provider value={{count, setCount}}>
            <RouterProvider router={router} future={{ v7_startTransition: true}}/>
        </CountContext.Provider>
        </>
    )
}

export default App;