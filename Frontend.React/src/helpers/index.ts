interface funProps<T>{
    a:T;
    b:T
}

export const identity = <T>(arg: T): T => {
  return arg;
};

// export function add<Number> (props:funProps<Number>) {
//   return (props.a + props.b);
// }
