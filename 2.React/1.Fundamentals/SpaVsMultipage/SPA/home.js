async function gotoHome(){
    const el = document.getElementById("root");

   var content = await fetch("./home.html").then(res=> res.text());

    el.innerHTML = content;
}
