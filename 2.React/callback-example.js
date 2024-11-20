function calculate(x, y){
    debugger
    calculatex(x,y,(res)=> {
        console.log(res)
    })
}

calculate(1,2)


function calculatex(x,y,callBack){
    const total = x + y *10;
    callBack(total);
}