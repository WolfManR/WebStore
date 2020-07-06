using WebStore.Domain.Models;

namespace WebStore.Interfaces.Services
{
    public interface ICartRepo
    {
        Cart Cart { get; set; }
    }
}