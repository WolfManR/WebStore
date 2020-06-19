﻿using WebStore.ViewModels.Products;

namespace WebStore.Infrastructure.Interfaces
{
    public interface ICartDataService
    {
        void AddToCart(int id);
        void DecrementFromCart(int id);
        void RemoveFromCart(int id);
        void RemoveAll();

        CartViewModel TransformFromCart();
    }
}
