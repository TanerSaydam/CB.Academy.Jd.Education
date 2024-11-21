import Link from "next/link";

const myStyle = {
    width: "100%", 
    height:"98vh", 
    display:"flex", 
    justifyContent: "center", 
    alignItems:"center", 
    flexDirection:"column"
}

export default function NotFound({reset}){
    return(
        <div style={myStyle}>
            <h1>Aradığın sayfa bulunamadı!</h1>
            <p>Geti dönmek için <Link href="/">tıklayın</Link></p>
        </div>
    )
}