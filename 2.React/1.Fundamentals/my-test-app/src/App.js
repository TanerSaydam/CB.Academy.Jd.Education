import { useState } from "react";
import { create } from "zustand";
import { devtools } from "zustand/middleware";

const useStore = create(devtools((set)=>({
    count: 0,
    isLoading: false,
    increment: ()=> set((state)=> ({count: state.count + 1})),
    decrement: ()=> set((state)=> ({count: state.count - 1})),
    manuelIncrement: (num)=> set((state)=> ({count: state.count + num})),
    incrementAsync: async () => {
        set((state)=> ({isLoading: true}))
        await new Promise((resolve) => setTimeout(resolve, 2000))
        set((state) => ({ count: state.count + 1, isLoading: false }
        ))
    } 
}),{name: "ismiburayaveriyoruz"}));


function App() { 
    const {count,isLoading} = useStore();
    return (
        <>
        {isLoading ? (<p>loading...</p>) : 
        (
            <>
            <p>Hello World!{count}</p>
            <Calculate/>
            </>
        )}
        </>
    )
}

function Calculate(){
    const [num, setNum]= useState(0);

    const {
        count, 
        increment, 
        decrement,
        manuelIncrement,
        incrementAsync,
        isLoading
    } = useStore();

    function checkLoading(){
        if(isLoading){
            return(<p>loading...</p>)
        }else{
            return(
                <>
                <input onChange={(e)=> setNum(e.target.value)} />
                    <button onClick={increment}>+</button> 
                    <button onClick={decrement}>-</button> 
                    <button onClick={()=> manuelIncrement(+num)}>+{num}</button> 
                    <button onClick={incrementAsync}>+Async</button> 
                </>
            )
        }
    }

    return(
        <>
        <p>Calculate App</p>  
        <p>{count}</p> 
        {checkLoading()}
        </>
        
    )
}

export default App;