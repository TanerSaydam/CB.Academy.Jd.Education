import { NavLink, Outlet } from "react-router-dom";

function Layout(){
    return(
        <>
        <ul>
            <li>
                <NavLink 
                to="/" 
                className={({isActive}) => isActive ? 'active' : ''}>
                    Home
                </NavLink>               
            </li>
            <li>
                <NavLink 
                to="/products" 
                className={({isActive}) => isActive ? 'active' : ''}>
                    Products
                </NavLink>                
            </li>
            <li>
                <button>Sign Out</button>
            </li>
        </ul>
        <Outlet/>
        </>
    )
}

export default Layout;