'use client'

import Link from "next/link";
import { usePathname, useRouter } from "next/navigation";
import { useState } from "react";

export function Header(){
    const router = useRouter();
    const pathName = usePathname();

	const{count, isLoading, error} = useState({})

	function signOut(){
		localStorage.clear();
		router.push("/login");
	}

	// useEffect(()=>{
	// 	dispatch(getCount());
	// },[dispatch])

	return (
		<div className="container">
			<nav className="navbar navbar-expand-lg bg-body-tertiary">
				<div className="container-fluid">
					<Link className="navbar-brand" href="/">
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
								<Link className={pathName === '/' ? 'nav-link active' : 'nav-link'} aria-current="page" href="/">
									<i className="fa-solid fa-home me-1"></i>
									Ana Sayfa
								</Link>
							</li>
							<li className="nav-item">
								<Link className={pathName=== "/products" ? 'nav-link active' : 'nav-link'} href="/products">
									<i className="fa-solid fa-box me-1"></i>
									Ürünler
								</Link>
							</li>
							<li className="nav-item">
								<Link className={pathName==="/orders" ? 'nav-link active' : 'nav-link'} href="/orders">
									<i className="fa-solid fa-file me-1"></i>
									Siparişler
								</Link>
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
		</div>
	)
}