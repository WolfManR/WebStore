using WebStore.Domain.ViewModels.Products;

namespace WebStore.Interfaces.Services
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
