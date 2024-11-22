import mongoose from "mongoose";

const ProductSchema = new mongoose.Schema({
  id: { type: String},
  name: {
    type: String,
    required: true,
  },
  imageUrl: {
    type: String,
    required: true,
  },
  price: {
    type: Number,
    required: true
  },
  stock: {
    type: Number,
    required: true,
  },
});

export default mongoose.models.Product || mongoose.model("Product", ProductSchema);