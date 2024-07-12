import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { store } from "../store";

export const empServices = createApi({
  reducerPath: "empServices",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://localhost:44311/api/Home/",
    prepareHeaders: (headers, { getState }: any) => {
      const token = getState().authUser.token;

      headers.set('content-type', `application/json`);
      if (token) {
        headers.set('Authorization', `Bearer ${token}`);
      }
      return headers;
    },
  }),
  endpoints: (builder) => ({
    getPersons: builder.query<any[], void>({
      query: () => 'Persons',
    }),
    getPerson: builder.query<any, any>({
      query: (id) => `Person?id=${id}`,
    }),
  }),
});

export const { useGetPersonsQuery, useGetPersonQuery } = empServices;
