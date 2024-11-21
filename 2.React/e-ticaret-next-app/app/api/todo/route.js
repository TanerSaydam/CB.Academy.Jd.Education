export async function GET(){
    const result = 
      await fetch("https://jsonplaceholder.typicode.com/todos")
            .then(res=> res.json());

    return Response.json(result);
}