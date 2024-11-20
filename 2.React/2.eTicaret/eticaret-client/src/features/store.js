import { configureStore } from "@reduxjs/toolkit";
import { countSlice, getCountSlice } from "./count";

export const store = configureStore({
    reducer: {
        counter: countSlice.reducer
    }
})