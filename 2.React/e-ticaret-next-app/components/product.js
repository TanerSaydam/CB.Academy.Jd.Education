import { formatCurrency } from "@/utilities/format";

export default function Product({val, addShoppingCart}){
    return(
        <div className="col-md-3 mt-1">
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
}