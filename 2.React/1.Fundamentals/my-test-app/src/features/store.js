import { configureStore } from "@reduxjs/toolkit";
import countReducer from "./Counter/count";
import { themeSlice } from "./theme";
import { todoSlice } from "./todo";

export const store = configureStore({
    reducer: {
        counter: countReducer,
        theme: themeSlice.reducer,
        todo: todoSlice.reducer
    }
})