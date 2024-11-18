import { useState } from "react";

function Product(){
    const [products, setProducts] = useState([]);

    return(
        <>
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
                                <button>Update</button>
                                <button>Delete</button>
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