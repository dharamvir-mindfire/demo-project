import * as React from "react";
import routes from "./routes";
import { useRoutes } from "react-router-dom";
import { useAppSelector } from "./store";
import Button from "./base-components/buttons";

export default function App() {
  const authUser = useAppSelector((state) => state?.authUser);
  const content = useRoutes(routes(!!authUser?.token));

  // return <Button variant="secondary" onHover={() => {}} />;
  return content;
}
