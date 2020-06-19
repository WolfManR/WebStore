using System.Collections.Generic;
using System.Linq;

namespace WebStore.ViewModels.Products
{
    public class CartViewModel
    {
        public IEnumerable<(ProductViewModel product, int quantity)> Items { get; set; }
        public int ItemsCount => Items?.Sum(item => item.quantity) ?? 0;
    }
}
