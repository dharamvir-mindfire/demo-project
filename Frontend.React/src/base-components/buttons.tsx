import React from 'react'
interface primaryProps{
  variant:'primary';
  onClick:Function
}
interface secondaryProps {
  variant:'secondary';
  onHover:Function
}

const Button = (props:primaryProps|secondaryProps) => {
  if(props.variant == "primary"){
    <div>Button</div>
  }
  if(props.variant == "secondary"){
    <div>Button</div>
  }
  return (
    <div>Button</div>
  )
}

export default Button