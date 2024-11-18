import axios from "axios";
import { useEffect, useState } from "react";

function Product(){
    const [products, setProducts] = useState([]);
    const [inputs, setInputs] = useState({});

    function setChange(e){
        const name = e.target.name;
        const value = e.target.value;
        setInputs(prev => ({...prev, [name]: value}))
    }

    async function save(){
        if(inputs.id){
            await axios.put(`http://localhost:8001/products/${inputs.id}`, inputs);
            setInputs({});
        }else{
            await axios.post("http://localhost:8001/products", inputs);
            setInputs({});
            
        }
        getAll();
        
    }

    const getAll = async()=> {
        const result = await axios.get("http://localhost:8001/products");
        setProducts(result.data);
    }

    async function deleteById(id){
        var result = window.confirm("YOu wnat to delete this record?");
        if(result){
            await axios.delete(`http://localhost:8001/products/${id}`);
            getAll();
        }
    }

    async function get(id) {
        var result = await axios.get(`http://localhost:8001/products/${id}`);

        setInputs(result.data);
    }

    useEffect(()=> {
        getAll();
    },[])

    return(
        <>
        <div>
            <div>
            FirstName: <input name="firstName" onChange={setChange} type="text" value={inputs["firstName"] ?? ""} />
            </div>
            <div>
            LastName: <input name="lastName" onChange={setChange} type="text" value={inputs["lastName"] ?? ""}/>
            </div>
            <div>
            Profession: <input name="profession" onChange={setChange} type="text" value={inputs["profession"] ?? ""}/>
            </div>
            <div>
            Salary: <input name="salary" onChange={setChange} type="number" value={inputs["salary"] ?? ""}/>
            </div>
            <button onClick={save}>Save</button>
        </div>
        <table>
            <thead>
                <tr>
                    <th>#</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Profession</th>
                    <th>Salary</th>
                    <th>Operation</th>
                </tr>
            </thead>
            <tbody>
                {products.map((val, i)=> {
                    return(
                        <tr key={i}>
                            <td>{i + 1}</td>
                            <td>{val.firstName}</td>
                            <td>{val.lastName}</td>
                            <td>{val.profession}</td>
                            <td>{val.salary}</td>
                            <td>
                                <button onClick={()=> get(val.id)}>Update</button>
                                <button onClick={()=> deleteById(val.id)}>Delete</button>
                            </td>
                        </tr>
                    )
                })}
            </tbody>
        </table>
        </>
    )
}

export default Product;