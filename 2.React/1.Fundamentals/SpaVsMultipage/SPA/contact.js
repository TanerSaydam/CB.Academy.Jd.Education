function gotoContact(){
    const el = document.getElementById("root");
    const content = `    
    <h1>Contact Page!</h1>
    <form>
        <div>
            <label>Subject</label>
            <input type="text">
        </div>
        <div>
            <button>Send</button>
        </div>
    </form>
    `

    el.innerHTML = content;
}
