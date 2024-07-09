import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const authServices = createApi({
  reducerPath: "authServices",
  baseQuery: fetchBaseQuery({ baseUrl: "https://localhost:44311/api/Account/", }),
  endpoints: (builder) => ({
    register: builder.mutation<any, void>({
      query: (payload: any) => ({
        url: `Register`,
        method: 'POST',
        headers: { "content-type": "application/json" },
        body: JSON.stringify(payload)
      }),
    }),
    login: builder.mutation<any, void>({
      query: (payload: any) => ({
        url: `Login`,
        method: 'POST',
        headers: { "content-type": "application/json" },
        body: JSON.stringify(payload)
      }),
    }),
  }),
});

export const { useRegisterMutation, useLoginMutation } = authServices;
