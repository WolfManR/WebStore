using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

using WebStore.Domain.ViewModels.Products;
using WebStore.Interfaces.Services;

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

        public IViewComponentResult Invoke(string sectionId)
        {
            var section_Id = int.TryParse(sectionId, out var id) ? id : (int?)null;

            var sections = GetSections(section_Id, out var parentSectionId);

            return View(new SelectableSectionsViewModel
            {
                Sections = sections,
                CurrentSectionId = section_Id,
                ParentSectionId = parentSectionId
            });
        }

        private IEnumerable<SectionViewModel> GetSections(int? sectionId,out int? parentSectionId)
        {
            parentSectionId = null;
            var sections = productDataService.GetSections().ToArray();

            var parentSections = sections.Where(s => s.ParentId is null);

            var parentSectionsViews = parentSections.Select(mapper.Map<SectionViewModel>).ToList();

            foreach (var parentSection in parentSectionsViews)
            {
                var childs = sections.Where(s => s.ParentId == parentSection.Id);

                foreach (var childSection in childs)
                {
                    if (childSection.Id == sectionId) parentSectionId = parentSection.Id;
                    parentSection.ChildSections.Add(mapper.Map<SectionViewModel>(childSection));
                }

                parentSection.ChildSections.Sort((a, b) => Comparer<double>.Default.Compare(a.Order, b.Order));
            }

            parentSectionsViews.Sort((a, b) => Comparer<double>.Default.Compare(a.Order, b.Order));

            return parentSectionsViews;
        }
    }
}
