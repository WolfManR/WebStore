using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels.Products;

namespace WebStore.Components
{
    public class SectionsViewComponent : ViewComponent
    {
        private readonly IProductDataService productDataService;
        private readonly IMapper mapper;

        public SectionsViewComponent(IProductDataService productDataService, IMapper mapper)
        {
            this.productDataService = productDataService;
            this.mapper = mapper;
        }

        public IViewComponentResult Invoke() => View(GetSections());

        private IEnumerable<SectionViewModel> GetSections()
        {
            var sections = productDataService.GetSections();

            var parent_sections = sections.Where(s => s.ParentId is null);

            var parent_Sections_views = parent_sections.Select(mapper.Map<SectionViewModel>).ToList();

            foreach (var parent_section in parent_Sections_views)
            {
                var childs = sections.Where(s => s.ParentId == parent_section.Id);

                foreach (var child_section in childs)
                    parent_section.ChildSections.Add(mapper.Map<SectionViewModel>(child_section));

                parent_section.ChildSections.Sort((a, b) => Comparer<double>.Default.Compare(a.Order, b.Order));
            }

            parent_Sections_views.Sort((a, b) => Comparer<double>.Default.Compare(a.Order, b.Order));

            return parent_Sections_views;
        }
    }
}
