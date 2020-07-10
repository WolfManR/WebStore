using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;

namespace WebStore.Domain.ViewModels
{
    public class BreadCrumbViewModel
    {
        public Section Section { get; set; }
        public BrandDTO Brand { get; set; }
        public string Product { get; set; }
    }
}