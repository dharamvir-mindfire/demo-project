import React, { useState } from "react";
const BuggyComponent = () => {
  const [items, setItems] = useState<any[]>([]);

  const addItem = () => {
    let newItems = items;
    newItems.push(items?.length + 1);
    console.log(items);
    setItems(newItems);
  };

  return (
    <div>
      <h1>Items</h1>
      <button onClick={addItem}>Add Item</button>
      <ul>
        {items.map((item) => (
          <li key={item}>{item}</li>
        ))}
      </ul>
    </div>
  );
};

export default BuggyComponent;
