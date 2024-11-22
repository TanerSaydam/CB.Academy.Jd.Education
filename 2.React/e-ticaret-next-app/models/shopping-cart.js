import mongoose from "mongoose";

const ShoppingCartSchema = new mongoose.Schema({
  productId: {
    type: mongoose.Schema.Types.ObjectId,
    required: true,
  },
  quantity: {
    type: Number,
    required: true,
    min:1
  },
});

export default mongoose.models.ShoppingCart || mongoose.model("ShoppingCart", ShoppingCartSchema);