import { useState } from "react";
import {
  Dialog,
  DialogBackdrop,
  DialogPanel,
  DialogTitle,
} from "@headlessui/react";
import { ExclamationTriangleIcon } from "@heroicons/react/24/outline";
import { UseQuery } from "@reduxjs/toolkit/dist/query/react/buildHooks";
import {
  FetchArgs,
  FetchBaseQueryError,
  FetchBaseQueryMeta,
  QueryDefinition,
} from "@reduxjs/toolkit/query";
import { BaseQueryFn } from "@reduxjs/toolkit/query";

const Modal = ({
  open,
  id,
  onRequestClose,
  useQuery,
  renderItem,
}: {
  open: boolean;
  id?: any;
  onRequestClose: (state: boolean) => void;
  useQuery: UseQuery<
    QueryDefinition<
      void,
      BaseQueryFn<
        string | FetchArgs,
        unknown,
        FetchBaseQueryError,
        {},
        FetchBaseQueryMeta
      >,
      never,
      any[],
      string
    >
  >;
  renderItem: (data: any) => React.ReactNode;
}) => {
  const { data, isLoading, isError } = useQuery(id);
  if (isLoading && open) {
    return (
      <div className="bg-[#00000078] text-white px-2 py-1 fixed left-0 right-0 top-0 bottom-0 flex justify-center items-center">
        <svg
          className="animate-spin h-5 w-5"
          color="white"
          viewBox="0 0 24 24"
        ></svg>
        Loading...
      </div>
    );
  }
  return (
    <Dialog className="relative z-10" open={open} onClose={onRequestClose}>
      <DialogBackdrop
        transition
        className="fixed inset-0 bg-gray-500 bg-opacity-75 transition-opacity data-[closed]:opacity-0 data-[enter]:duration-300 data-[leave]:duration-200 data-[enter]:ease-out data-[leave]:ease-in"
      />

      <div className="fixed inset-0 z-10 w-screen overflow-y-auto">
        <div className="flex min-h-full items-end justify-center p-4 text-center sm:items-center sm:p-0">
          <DialogPanel
            transition
            className="relative transform overflow-hidden rounded-lg bg-white text-left shadow-xl transition-all data-[closed]:translate-y-4 data-[closed]:opacity-0 data-[enter]:duration-300 data-[leave]:duration-200 data-[enter]:ease-out data-[leave]:ease-in sm:my-8 sm:w-full sm:max-w-lg data-[closed]:sm:translate-y-0 data-[closed]:sm:scale-95"
          >
            <div className="bg-white px-4 pb-4 pt-5 sm:p-6 sm:pb-4">
              <div className="sm:flex sm:items-start">
                <div className="mx-auto flex h-12 w-12 flex-shrink-0 items-center justify-center rounded-full bg-red-100 sm:mx-0 sm:h-10 sm:w-10">
                  <ExclamationTriangleIcon
                    className="h-6 w-6 text-red-600"
                    aria-hidden="true"
                  />
                </div>
                <div className="mt-3 text-center sm:ml-4 sm:mt-0 sm:text-left">
                  <DialogTitle
                    as="h3"
                    className="text-base font-semibold leading-6 text-gray-900"
                  >
                    Employee Detail
                  </DialogTitle>
                </div>
              </div>
            </div>
            <div className="bg-white px-4 pb-4 pt-5 sm:p-6 sm:pb-4">
              {Array.isArray(data)
                ? data?.map((item) => renderItem(item))
                : renderItem(data)}
            </div>
            <div className="bg-gray-50 px-4 py-3 gap-2 sm:flex sm:flex-row-reverse sm:px-6">
              <button
                type="button"
                className="inline-flex w-full justify-center rounded-md bg-red-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-red-500 sm:w-auto"
                onClick={() => onRequestClose(false)}
              >
                Ok
              </button>
            </div>
          </DialogPanel>
        </div>
      </div>
    </Dialog>
  );
};

export default Modal;
