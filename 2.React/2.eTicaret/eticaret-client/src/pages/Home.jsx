import axios from "axios";
import { useEffect, useState } from "react";
import { api } from "../constants";
import { formatCurrency } from "../utilities/format";
import { useDispatch } from "react-redux";
import { increment } from "../features/count";

function Home(){
	const [products, setProducts] = useState([]);
	const [orgProducts, setOrgProducts] = useState([]);
	const dispatch = useDispatch();

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
			dispatch(increment());
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
			{products.map((val,i)=> {
				return(
					<div className="col-md-3 mt-1" key={i}>
						<div className="card">
							<div className="card-header" style={{minHeight: "250px"}}>
								<h6>{val.name}</h6>
								<img src={val.imageUrl} style={{width: '100%'}} alt="Resim bulunamadı" />
							</div>
							<div className="card-body text-center">
								<h6 className="text-success">{formatCurrency(val.price)}</h6>
								<button onClick={()=> addShoppingCart(val.id)} className="btn btn-success">
									<i className="fa-solid fa-cart-plus me-1 fa-bounce"></i>
									Sepete Ekle
								</button>
							</div>
						</div>
					</div>
				)
			})}
		</div>
		</>
	)
}

export default Home;