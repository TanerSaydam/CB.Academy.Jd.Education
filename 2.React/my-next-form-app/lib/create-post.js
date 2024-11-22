'use server'

import { redirect } from "next/navigation";

export async function createPost(formData) {    
    console.log(formData);

    return redirect("/");
}