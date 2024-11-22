import shoppingCart from "@/models/shopping-cart";

export async function GET() {
    var result = await shoppingCart.countDocuments();

    return Response.json(result);
}