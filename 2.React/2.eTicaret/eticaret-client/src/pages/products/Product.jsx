import { useEffect, useState, useContext } from "react";
import { formatCurrency } from "../../utilities/format";
import axios from "axios";
import { api } from "../../constants";
import { useNavigate } from "react-router-dom";
import { CountContext } from "../..";

function Product(){
	const [products, setProducts] = useState([]);
	const [orgProducts, setOrgProducts] = useState([]);

	const navigate = useNavigate();

	async function getAll(){
		try {
			var result = await axios.get(`${api}/api/products`);
			setProducts(result.data)
			setOrgProducts(result.data)
		} catch (error) {
			console.log(error);		
		}
	}

	useEffect(()=> {
		getAll();

		return ()=>{
			setProducts([]);
			setOrgProducts([]);
		}
	},[])

	function searchChange(e){
		const value = e.target.value;
		setProducts(orgProducts.filter(p=> p.name.toLowerCase().includes(value.toLowerCase())));
	}

	async function deleteById(id) {
		const result = window.confirm("You want to delete this record?");
		try {
			console.log(result)
			if(result){
				await axios.delete(`${api}/api/products?id=${id}`);
				getAll();

			}
		} catch (error) {
			console.log(error);			
		}

	}

	return(
		<>
		<div className="form-group row">
			<div className="col-md-8">
				<button className="btn btn-primary" onClick={()=> navigate("/products/create")}>
					<i className="fa-solid fa-plus me-1"></i>
					Ürün Ekle
				</button>
			</div>
			<div className="col-md-4">
				<input type="search" className="form-control" placeholder="Aranacak değer girin..." onChange={searchChange}/>
			</div>
		</div>
		<div className="form-group mt-1">
			<table className="table table-hover">
				<thead>
					<tr>
						<th>#</th>
						<th>Ürün Resmi</th>
						<th>Adı</th>
						<th>Stok Adedi</th>
						<th>Birim Fiyatı</th>
						<th>İşlemler</th>
					</tr>
				</thead>
				<tbody>
					{products.map((val, i)=> {
						return(
							<tr key={i}>
								<td>{i + 1}</td>
								<td>
									<img src={val.imageUrl} alt="Resim bulunamadı" width="50" />
								</td>
								<td>{val.name}</td>
								<td>{val.stock}</td>
								<td>{formatCurrency(val.price)}</td>
								<td>
									<button className="btn btn-primary btn-sm">
										<i className="fa-solid fa-edit"></i>	
									</button>
									<button onClick={() => deleteById(val.id)} className="btn btn-danger btn-sm ms-1" >
										<i className="fa-solid fa-trash"></i>	
									</button>
								</td>
							</tr>
						)
					})}
				</tbody>
			</table>
		</div>
		</>
	)
}

export default Product;