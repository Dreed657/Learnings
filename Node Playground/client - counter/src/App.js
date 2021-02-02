import React, { useState, useEffect } from 'react';
import './App.css';

export default function App() {
  const [count, setCount] = useState("");

  return (
    <div className="container mt-4">
      <div className="border p-5 text-center">
        <h3>Counter</h3>
        <p>{count}</p>
        <div className="row">
          <div className="col">
            <button className="btn btn-success" onClick={() => setCount(count + 1)}>
              Up
            </button>
          </div>
          <div className="col">
            <button className="btn btn-danger" onClick={() => setCount(count - 1)}>
              Down
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}
