function gotoProduct(){
    const el = document.getElementById("root");
    const content = `    
    <h1>Product Page!</h1>
    <ul>
        <li>Product 1</li>
        <li>Product 2</li>
        <li>Product 3</li>
    </ul> 
    `

    el.innerHTML = content;
}
