import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { decrement, increment, incrementByValue } from "./features/Counter/count";
import { changeTheme } from "./features/theme";
import { getTodo } from "./features/todo";
import { useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

function App() {
    const count = useSelector((store) => store.counter.count);
    const themeValue = useSelector((store)=> store.theme.value);
    const dispatch = useDispatch();

    const data = useSelector((store)=> store.todo.data);
    const isLoading = useSelector((store)=> store.todo.isLoading);
    const error = useSelector((store)=> store.todo.error);

    useEffect(()=>{
        dispatch(getTodo())
    },[dispatch])

    return (
        <>
            {/* {isLoading ? (<p>loading....</p>) : null}
            {error ? (<p style={{color:"red"}}>{error}</p>) : null}
            <p>Hello World!{count}</p>
            <button onClick={()=> dispatch(changeTheme())}>Change Theme</button>
            <p>Theme: {themeValue}</p>

            <button onClick={()=> dispatch(getTodo())}>Get Todo List</button> */}

            <Todo/>
{/* 
            <Calculate /> */}
        </>
    )
}

function Calculate() {
    const count = useSelector((store) => store.counter.count);
    const [num, setNum] = useState(0);
    const isLoading = false;
    const dispatch = useDispatch();

    function checkLoading() {
        if (isLoading) {
            return (<p>loading...</p>)
        } else {
            return (
                <>
                    <input onChange={(e) => setNum(e.target.value)} />
                    <button onClick={() => dispatch(increment())}>+</button>
                    <button onClick={() => dispatch(decrement())}>-</button>
                    <button onClick={()=> dispatch(incrementByValue(+num))}>+{num}</button> 
                    {/* <button onClick={incrementAsync}>+Async</button>  */}
                </>
            )
        }
    }

    return (
        <>
            <p>Calculate App</p>
            <p>{count}</p>
            {checkLoading()}
        </>

    )
}

async function getTodos() {
    await new Promise(res => setTimeout(res,1000));
    const result = await axios.get("https://jsonplaceholder.typicode.com/todos");

    return result.data;
}

function Todo(){
    const queryClient = useQueryClient();
    const {data,isLoading,refetch, error} = useQuery({
        queryKey: ["todo"],
        queryFn: getTodos,
        enabled: false,
        staleTime: 0,        
    });
    
    function getAll(){
        queryClient.removeQueries("todo");
        refetch();
    }

    if(isLoading){
        return <p>loading...</p>
    }

    if(error){
        return <p>{error.message}</p>
    }

    return(
        <>
        <button onClick={getAll}>Get Todo List</button>
            <ul>
                {data?.map((val, i) => <li key={i}>{val.title}</li>)}
            </ul>
        </>
    )
}

export default App;