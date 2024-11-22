import { connection } from "@/lib/db";
import product from "@/models/product";
import { api } from "@/utilities/contants";
import axios from "axios";

process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0';

export async function GET(){
    connection();
    var res = await product.find();

    return Response.json(res);
}