import { combineReducers } from "@reduxjs/toolkit";
import { authServices } from "../services/authServices";
import { authSlice } from "../pages/Login/Redux";
import { empServices } from "../services/empServices";

export const rootReducers = combineReducers({
    [authServices.reducerPath]: authServices.reducer,
    [empServices.reducerPath]: empServices.reducer,
    [authSlice.name]: authSlice.reducer
})

export * from '../pages/Login/Redux'