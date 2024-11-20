import { createSlice } from "@reduxjs/toolkit";

export const themeSlice = createSlice({
    name: "my-theme-opitons",
    initialState: {
        value: "light"
    },
    reducers: {
        changeTheme: (state)=> {
            state.value === "light" ? state.value = "dark" :  state.value = "light" 
        }
    }
});

export const {changeTheme} = themeSlice.actions;