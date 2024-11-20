import { createSlice } from "@reduxjs/toolkit";

export const countSlice = createSlice({
    name: "my-count",
    initialState: {
        count: 55
    },
    reducers: {
        increment: state => {
            state.count += 1
        },
        decrement: state => {
            state.count -= 1
        },
        incrementByValue: (state, action)=>{
            state.count += action.payload;
        }
    }
});

export const {increment,decrement,incrementByValue} = countSlice.actions;
export default countSlice.reducer;