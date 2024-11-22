import shoppingCart from "@/models/shopping-cart";

export async function POST(request) {
    const res = await request.json()
    const cart = new shoppingCart(res);
    await cart.save();

    return Response.json({});   
}