using System.Collections.Generic;

namespace WebStore.Domain.ViewModels.Products
{
    public class SelectableBrandsViewModel
    {
        public IEnumerable<BrandViewModel> Brands { get; set; }
        public int? CurrentBrandId { get; set; }
    }
}