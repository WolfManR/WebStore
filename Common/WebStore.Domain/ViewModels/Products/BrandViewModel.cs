using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.ViewModels.Products
{
    public class BrandViewModel : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductsCount { get; set; }
    }
}
