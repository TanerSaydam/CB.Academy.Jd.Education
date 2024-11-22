import shoppingCart from "@/models/shopping-cart";

export async function GET() {
    var result = await shoppingCart.aggregate([
        {
            $lookup: {
                from: "products",
                localField:"productId",
                foreignField: "_id",
                as: "product"
            }
        },
        {
            $unwind: "$product"
        }
    ]);

    return Response.json(result);
}