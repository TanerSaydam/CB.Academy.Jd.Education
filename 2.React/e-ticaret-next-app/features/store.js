import { api } from "@/utilities/contants";
import axios from "axios";
import { create } from "zustand";

export const useStore = create((set) => ({
    count: 0,
    isLoading: false,
    error: null,
    increment: () => set((state) => ({ count: state.count + 1 })),
    decrement: () => set((state) => ({ count: state.count - 1 })),
    get: async () => {
        set(() => ({ isLoading: true }))
        try {
            var result = await axios.get(`/api/shopping-carts/get-count`);
            set(() => ({ count: result.data, isLoading: false }))
        } catch (error) {
            set(() => ({ error: result.error.message, isLoading: false }))
        }
    }
}));