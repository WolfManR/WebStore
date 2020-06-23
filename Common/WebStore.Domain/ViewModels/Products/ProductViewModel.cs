using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.ViewModels.Products
{
    public class ProductViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        public BrandViewModel Brand { get; set; }
        public SectionViewModel Section { get; set; }
    }
}
