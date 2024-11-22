import { seedProductData } from "@/lib/seed-data";

export async function GET() {
    seedProductData();
    return Response.json({message: "Is successful"});
}