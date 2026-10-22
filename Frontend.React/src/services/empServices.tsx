import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { store } from "../store";

export const empServices = createApi({
  reducerPath: "empServices",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://localhost:44311/api/v2/Persons/",
    prepareHeaders: (headers, { getState }: any) => {
      const token = getState().authUser.token;

      headers.set("content-type", `application/json`);
      if (token) {
        headers.set("Authorization", `Bearer ${token}`);
      }
      return headers;
    },
  }),
  endpoints: (builder) => ({
    getPersons: builder.query<any[], any>({
      query: (page=0) => "GetAll?page=" + page,
    }),
    getPerson: builder.query<any, any>({
      query: (id) => `Get?id=${id}`,
    }),
    addPerson: builder.mutation<any, any>({
      query: (payload) => ({
        url: `Add`,
        method: "POST",
        body: JSON.stringify(payload),
      }),
      async onQueryStarted(payload, { dispatch, queryFulfilled }) {
        try {
          const { data } = await queryFulfilled;
          console.log(data);
          const patchResult = dispatch(
            empServices.util.updateQueryData(
              "getPersons",
              undefined,
              (draft) => {
                draft.push(data);
              }
            )
          );
        } catch {}
      },
    }),
    updatePerson: builder.mutation<any, any>({
      query: (payload) => ({
        url: `Update`,
        method: "PUT",
        body: JSON.stringify(payload),
      }),
      async onQueryStarted(payload, { dispatch, queryFulfilled }) {
        try {
          const { data } = await queryFulfilled;
          const patchResult = dispatch(
            empServices.util.updateQueryData(
              "getPersons",
              undefined,
              (draft) => {}
            )
          );
        } catch {}
      },
    }),
  }),
});

export const {
  useGetPersonsQuery,
  useGetPersonQuery,
  useAddPersonMutation,
  useUpdatePersonMutation,
} = empServices;
