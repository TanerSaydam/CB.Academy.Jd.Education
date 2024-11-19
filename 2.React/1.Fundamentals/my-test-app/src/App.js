import { createContext, useContext, useState } from "react";

const CountContext = createContext(0);

function App() { 
    const [count, setCount]=useState(0);
    const [isLoading, setIsLoading]=useState(false);
    const [theme, setTheme]=useState("light");
    return (
        <CountContext.Provider value={{count,setCount, isLoading,theme}}>
            <p>Hello World!{count}</p>
            <Calculate/>
        </CountContext.Provider>
    )
}

function Calculate(){
    const data = useContext(CountContext);
    console.log(data.count);
    
    return(
        <>
        <p>Calculate App</p>    
        <p>{data.theme}</p>
        <p>{data.count}</p> 
        <button onClick={()=> data.setCount(prev => prev +1)}>+</button> 
        <button onClick={()=> data.setCount(prev => prev -1)}>-</button> 
        </>
        
    )
}

export default App;