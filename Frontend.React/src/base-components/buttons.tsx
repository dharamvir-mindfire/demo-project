import { PropsOf } from "@headlessui/react/dist/types";
import React, { ElementType, HTMLAttributes, ReactNode, createElement,ReactElement } from "react";
import { LinkProps } from "react-router-dom";

interface linkProps extends LinkProps {
  as: "a";
}
interface buttonProps extends React.ButtonHTMLAttributes<ElementType> {
  as: 'button';
}
const Button = (props: linkProps | buttonProps) => {
  const element = createElement(props?.as, {...props}, props.children)
  return element
};

export default Button;
