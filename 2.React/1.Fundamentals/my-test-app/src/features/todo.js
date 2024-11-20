import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";

export const getTodo = createAsyncThunk(
    "Get Todo List",
    async () => {
        await new Promise(resolve => setTimeout(resolve,1000));
        var result = await axios.get("https://jsonplaceholder.typicode.com/todos")
        return result.data;
    }
)

export const todoSlice = createSlice({
    name: "todo-list",
    initialState: {
        data: [],
        isLoading: false,
        error: null
    },
    extraReducers: builder => {
        builder
        .addCase(getTodo.pending, (state)=>{
            state.isLoading = true;
        })
        .addCase(getTodo.fulfilled, (state, action)=>{
            state.isLoading = false;
            state.data = action.payload;
        })
        .addCase(getTodo.rejected, (state, action)=>{
            state.isLoading = false;
            state.error = action.error.message
        })
    }
})