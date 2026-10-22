import React, { FormEvent, FormEventHandler, useEffect, useState } from "react";
import Modal from "../../base-components/Modal";
import {
  useAddPersonMutation,
  useGetPersonsQuery,
  useUpdatePersonMutation,
} from "../../services/empServices";
import { PencilSquareIcon } from "@heroicons/react/24/outline";
import { removeAuthUser } from "../Login/Redux";
import { useAppDispatch } from "../../store";

const Component = () => {
  const dispatch = useAppDispatch();
  const [page, setPage] = useState(1);
  const { data, error, isError, status, refetch } = useGetPersonsQuery(page);
  const [add] = useAddPersonMutation();
  const [update] = useUpdatePersonMutation();
  const [modal, setModal] = useState<boolean>(false);
  const [model, setModel] = useState<any>();

  useEffect(() => {
    if ((error as any)?.status == 401) {
      dispatch(removeAuthUser());
    }
  }, [(error as any)?.status]);

  const addUpdateItem = (item = undefined) => {
    setModel(item);
    setModal(true);
  };

  const onSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const formData = new FormData(event?.currentTarget);
    const name = formData.get("name");
    const email = formData.get("email");
    const phoneNumber = formData.get("phoneNumber");
    const address = formData.get("address");
    if (model?.id) {
      update({ id: model?.id, name, email, phoneNumber, address }).then(
        (res) => {
        }
      );
    } else {
      add({ name, email, phoneNumber, address }).then((res) => {
      });
    }
    setModal(false);
    setModel(undefined);
  };

  return (
    <div>
      <h1>Items</h1>
      <button onClick={() => addUpdateItem()}>Add Item</button>
      <ul>
        {data?.map((item) => (
          <li className="flex" key={item?.id}>
            {item?.name || "NA"}{" "}
            <PencilSquareIcon
              onClick={() => {
                addUpdateItem(item);
              }}
              className=" cursor-pointer size-5"
            />
          </li>
        ))}
      </ul>
      <Modal open={modal} onRequestClose={setModal}>
        <form id="form-element" onSubmit={onSubmit}>
          <input
            name="name"
            placeholder="Name"
            className="w-[100%] border border-gray-500 p-1.5 rounded-sm mb-1"
            required
            defaultValue={model?.name}
          />
          <input
            name="email"
            placeholder="Email"
            className="w-[100%] border border-gray-500 p-1.5 rounded-sm mb-1"
            required
            defaultValue={model?.email}
          />
          <input
            name="phoneNumber"
            placeholder="Phone Number"
            className="w-[100%] border border-gray-500 p-1.5 rounded-sm mb-1"
            required
            defaultValue={model?.phoneNumber}
          />
          <textarea
            name="address"
            placeholder="Address"
            className="w-[100%] border border-gray-500 p-1.5 rounded-sm mb-1"
            required
            defaultValue={model?.address}
          />
          <input
            type="submit"
            value="Submit"
            className=" cursor-pointer mt-2 border border-gray-800 text-gray-800 p-1 rounded"
          />
        </form>
      </Modal>
    </div>
  );
};

export default Component;
