'use client'

import { useEffect, useState } from "react";

export default function Home() {
  const [todo,setTodo] = useState([]);

  async function getAll(){
    const result = 
      await fetch("/api/todo")
            .then(res=> res.json());
    
    setTodo(result);
  }

  useEffect(()=>{
    getAll();
  },[])

  return (
    <ul>
      {todo.map((val, i)=> <li key={i}>{val.title}</li>)}
    </ul>
  );
}