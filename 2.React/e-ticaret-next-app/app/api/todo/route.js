import { connection } from "@/lib/db";


export async function GET(){
  
  connection();
    const result = 
      await fetch("https://jsonplaceholder.typicode.com/todos")
            .then(res=> res.json());

    return Response.json(result);
}