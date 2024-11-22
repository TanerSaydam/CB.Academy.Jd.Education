'use client'

import { api } from "@/utilities/contants";
import { formatCurrency } from "@/utilities/format";
import axios from "axios";
import { useEffect, useState } from "react";

export default function Orders(){
    const [orders, setOrders] = useState([]);

	async function getAll() {
		try {
			var result = await axios.get(`${api}/api/orders`);
			setOrders(result.data);
		} catch (error) {
			console.log(error);
		}
	}

	useEffect(() => {
		getAll();

		return () => {
			setOrders([])
		}
	}, []);	

	return (
		<>
			<table className="table table-hover">
				<thead>
					<tr>
						<th>#</th>
						<th>Ürün Resmi</th>
						<th>Ürün Adı</th>
						<th>Adet</th>
						<th>Birim Fiyatı</th>
						<th>Toplam</th>
					</tr>
				</thead>
				<tbody>
					{orders.map((val, i) => {
						return (
							<tr key={i}>
								<td>{i + 1}</td>
								<td>
									<img src={val.product.imageUrl} alt="Resim bulunamadı" width="50" />
								</td>
								<td>{val.product.name}</td>
								<td>{formatCurrency(val.quantity)}</td>
								<td>{formatCurrency(val.price)}</td>
								<td>{formatCurrency(val.quantity + val.price)}</td>
							</tr>
						)
					})}
				</tbody>
			</table>
		</>
	)
}