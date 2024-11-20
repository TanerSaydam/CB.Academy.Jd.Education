import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { api } from "../constants";

export const countSlice = createSlice({
    name: "shopping-cart-count",
    initialState: {
        count: 0,
        isLoading: false,
        error: null
    },
    reducers: {
        increment: (state)=> {
            state.count += 1;
        },
        decrement: (state)=> {
            state.count -= 1;           
        }
    },
    extraReducers: builder => {
        builder
        .addCase(getCount.pending, (state)=>{
            state.isLoading = true;
        })
        .addCase(getCount.fulfilled, (state,action)=>{
            state.isLoading = false;
            state.count = action.payload;
        })
        .addCase(getCount.rejected, (state,action)=>{
            state.isLoading = false;
            state.error = action.error.message;
        })
    }
});

export const getCount = createAsyncThunk(
    "get-shopping-cart-count",
    async ()=>{
        await new Promise(resolve => setTimeout(resolve,1000));
        const result = await axios.get(`${api}/api/ShoppingCarts/count`);
        return result.data
    }
)

export const {increment, decrement} = countSlice.actions;