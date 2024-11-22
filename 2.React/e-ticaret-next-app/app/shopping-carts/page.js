'use client'

import { useStore } from "@/features/store";
import { api } from "@/utilities/contants";
import { formatCurrency } from "@/utilities/format";
import axios from "axios";
import { useEffect, useState } from "react";

export default function ShoppingCart(){
    const [carts, setCarts] = useState([]);
	const [total, setTotal] = useState(0);
	const { decrement, get} = useStore();

	async function getAll() {
		try {
			var result = await axios.get(`/api/shopping-carts`);
			setCarts(result.data);

			let total = 0;
			for(let val of result.data){
				total += (val.product.price * val.quantity)
			}			

			setTotal(total);

		} catch (error) {
			console.log(error);			
		}
	}

	useEffect(()=> {
		getAll();

		return () => {
			setCarts([])
		}
	}, []);

	async function deleteById(id) {
		const result = window.confirm("Ürünü sepetten kaldırmak istiyor musunuz?");
		try {
			if(result){
				await axios.delete(`${api}/api/shoppingcarts?id=${id}`);
				getAll();
				decrement()
			}			
		} catch (error) {
			console.log(error);			
		}
	}
	
	async function pay() {
		const result = window.confirm("Ödemeyi onaylıyor msuunuz?");
		try {
			if(result){
				await axios.get(`${api}/api/shoppingcarts/pay`);
				getAll();
                get();
			}
		} catch (error) {
			console.log(error);		
		}
	}

	return(
		<div className="row">
			<div className="col-md-8">
				<table className="table table-hover">
					<thead>
						<tr>
							<th>#</th>
							<th>Ürün Resmi</th>
							<th>Ürün Adı</th>
							<th>Adet</th>
							<th>Birim Fiyatı</th>
							<th>Toplam</th>
							<th>İşlemler</th>
						</tr>
					</thead>
					<tbody>
						{carts.map((val,i)=> {
							return(
								<tr key={i}>
									<td>{i + 1}</td>
									<td>
										<img src={val.product.imageUrl} alt="Resim bulunamadı" width="50" />
									</td>
									<td>{val.product.name}</td>
									<td>{formatCurrency(val.quantity)}</td>
									<td>{formatCurrency(val.product.price)}</td>
									<td>{formatCurrency(val.quantity * val.product.price)}</td>
									<td>
										<button onClick={() => deleteById(val.id)} className="btn btn-outline-danger btn-sm">
											<i className="fa-solid fa-trash"></i>
										</button>
									</td>
								</tr>
							)
						})}
					</tbody>
				</table>
			</div>
			<div className="col-md-4">
				<div className="card text-center">
					<div className="card-header">
						<h3 className="text-success" style={{display:"flex", flexDirection:"column"}}>
							<span className="me-1">Toplam</span> 
							{formatCurrency(total)}
						</h3>						
					</div>
					<div className="card-body">
						<button onClick={pay} className="btn btn-danger w-100 btn-lg">
							<i className="fa-solid fa-credit-card me-1"></i>
							Ödeme Yap
						</button>
					</div>
				</div>
			</div>
		</div>
	)
}