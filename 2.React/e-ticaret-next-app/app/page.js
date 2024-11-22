'use client'

import Product from "@/components/product";
import { useStore } from "@/features/store";
import { api } from "@/utilities/contants";
import axios from "axios";
import { useEffect, useState } from "react";

export default function Home(){
    const [products, setProducts] = useState([]);
	const [orgProducts, setOrgProducts] = useState([]);
    const {increment} = useStore();

	async function getAll() {
		try {
			var result = await axios.get(`${api}/api/products`);
			setProducts(result.data.data);
			setOrgProducts(result.data.data);
		} catch (error) {
			console.log(error);			
		}
	}

	function searchChange(e){
		const value = e.target.value;
		setProducts(orgProducts.filter(p=> p.name.toLowerCase().includes(value.toLowerCase())));
	}

	useEffect(()=> {
		getAll();

		return ()=> {
			setProducts([])
			setOrgProducts([])
		}
	}, [])	


	async function addShoppingCart(productId) {
		try {
			debugger
			const data = {
				productId: productId,
				quantity: 1
			};

			await axios.post(`${api}/api/shoppingcarts`, data);
			increment();
		} catch (error) {
			console.log(error);		
		}
	}

	return(
		<>
		<div className="form-group">
			<input type="search" className="form-control" onChange={searchChange} placeholder="Aranacak değer girin..."/>
		</div>
		<div className="form-group row mt-2">
			{products.map((val,i)=> 
                    <Product key={i} val={val} addShoppingCart={addShoppingCart}  />
                )}
		</div>
		</>
	)
}