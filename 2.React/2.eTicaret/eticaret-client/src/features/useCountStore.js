import axios from "axios";
import { create } from "zustand";
import { devtools } from "zustand/middleware";
import { api } from "../constants";

export const useCountStore = create(devtools((set)=>({
    count: 0,
    isLoading: false,
    increment: ()=> {
        debugger
        set((state)=> ({count: state.count + 1}))
    },
    decrement: ()=> set((state)=> ({count: state.count - 1})),
    getCount: async ()=> {
        set(()=> ({isLoading: true}))
        var result = await axios.get(`${api}/api/ShoppingCarts/count`);
        set(()=> ({count: result.data, isLoading: false}));
    }
})));