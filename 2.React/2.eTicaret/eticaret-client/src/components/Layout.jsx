import { Link, NavLink, Outlet, useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { useCountStore } from "../features/useCountStore";

function Layout() {
	const navigate = useNavigate();
	const {count, isLoading, getCount} = useCountStore();

	function signOut(){
		localStorage.clear();
		navigate("/login");
	}

	useEffect(()=>{
		getCount();
	},[getCount])

	return (
		<div className="container">
			<nav className="navbar navbar-expand-lg bg-body-tertiary">
				<div className="container-fluid">
					<Link className="navbar-brand" to="/">
						TS eTicaret
					</Link>
					<button
						className="navbar-toggler"
						type="button"
						data-bs-toggle="collapse"
						data-bs-target="#navbarSupportedContent"
						aria-controls="navbarSupportedContent"
						aria-expanded="false"
						aria-label="Toggle navigation"
					>
						<span className="navbar-toggler-icon" />
					</button>
					<div className="collapse navbar-collapse" id="navbarSupportedContent">
						<ul className="navbar-nav me-auto mb-2 mb-lg-0">
							<li className="nav-item">
								<NavLink className={({isActive})=> isActive ? 'nav-link active' : 'nav-link'} aria-current="page" to="/">
									<i className="fa-solid fa-home me-1"></i>
									Ana Sayfa
								</NavLink>
							</li>
							<li className="nav-item">
								<NavLink className={({isActive})=> isActive ? 'nav-link active' : 'nav-link'} to="/products">
									<i className="fa-solid fa-box me-1"></i>
									Ürünler
								</NavLink>
							</li>
							<li className="nav-item">
								<NavLink className={({isActive})=> isActive ? 'nav-link active' : 'nav-link'} to="/orders">
									<i className="fa-solid fa-file me-1"></i>
									Siparişler
								</NavLink>
							</li>
						</ul>
						<button type="button" onClick={()=> navigate("/shopping-carts")} className="btn btn-primary position-relative">
							<i className={"fa-solid fa-shopping-cart me-1 " + (count > 0 ? 'fa-beat' : '')}></i>
							Sepetim
							<span className="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger">
								{isLoading ? '...' : count}
							</span>
						</button>
						<button type="button" onClick={signOut} className="btn btn-danger ms-3">
							<i className="fa-solid fa-power-off me-1"></i>
							Çıkış Yap
						</button>
					</div>
				</div>
			</nav>
			<hr />
			<Outlet />
		</div>
	)
}

export default Layout;