using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.ViewModels.Products
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int ProductsCount { get; set; }
    }
}
