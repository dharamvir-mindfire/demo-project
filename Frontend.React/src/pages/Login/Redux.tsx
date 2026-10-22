import { createSlice } from "@reduxjs/toolkit";

interface authUserProps {
    fullName: string;
    email: string;
    phoneNumber: string;
    token: string;
}
const initialState: authUserProps = {
    fullName: '',
    email: '',
    phoneNumber: '',
    token: ''
}

export const authSlice = createSlice({
    name: 'authUser',
    initialState,
    reducers: {
        setAuthUser: (state: authUserProps, action) => {
            return action.payload
        },
        removeAuthUser: () => {
            return initialState
        }
    }
})

export const { setAuthUser, removeAuthUser } = authSlice.actions

export const authUserReducer = authSlice.reducer;