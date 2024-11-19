import axios from "axios";
import { useState } from "react";
import { api } from "../constants";
import { useNavigate } from "react-router-dom";

function Login(){
	const navigate = useNavigate();
	const [userName, setUserName] = useState("");
	const [password, setPassword] = useState("");
	
	async function login(e){
		e.preventDefault();

		const data = {
			userName: userName,
			password: password
		}
		
		try {
			var result = await axios.post(`${api}/api/Auth`,data);
			localStorage.setItem("token",result.data.token);
			navigate("/");
		} catch (error) {
			console.log(error);			
		}	
	}

	return(
		<div style={{height: "100vh", width: "100%", display: "flex", justifyContent: "center", alignItems: "center"}}>
				<div className="col-md-4 col-12 card">
					<div className="card-header">
						<h4>Giriş Sayfası</h4>
						<p>Giriş yapmak için lütfen bilgilerinizi girin</p>
					</div>
					<div className="card-body">
						<form autoComplete="off" onSubmit={login}>
							<div className="form-group">
								<label>Kullanıcı Adı</label>
								<input type="text" required name="userName" className="form-control" onChange={(e)=> setUserName(e.target.value)}/>
							</div>
							<div className="form-group mt-1">
								<label>Şifre</label>
								<input type="text" required name="password" className="form-control" onChange={(e)=> setPassword(e.target.value)}/>
							</div>
							<div className="form-group mt-3 d-flex" style={{justifyContent:"end"}}>
								<button type="submit" className="btn btn-primary">
									<i className="fa-solid fa-lock me-1"></i>
									Giriş Yap
								</button>
							</div>
						</form>
					</div>
				</div>
		</div>
	)
}

export default Login;