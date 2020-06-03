﻿using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Components
{
    public class SectionsViewComponent : ViewComponent
    {
        private readonly IProductDataService productDataService;
        public SectionsViewComponent(IProductDataService productDataService)
        {
            this.productDataService = productDataService;
        }

        public IViewComponentResult Invoke() => View(GetSections());

        private IEnumerable<SectionViewModel> GetSections()
        {
            var sections = productDataService.GetSections();

            var parent_sections = sections.Where(s => s.ParentId is null);

            var parent_Sections_views = parent_sections.Select(
                s => new SectionViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Order = s.Order,
                })
               .ToList();

            foreach (var parent_section in parent_Sections_views)
            {
                var childs = sections.Where(s => s.ParentId == parent_section.Id);

                foreach (var child_section in childs)
                    parent_section.ChildSections.Add(new SectionViewModel
                    {
                        Id = child_section.Id,
                        Name = child_section.Name,
                        Order = child_section.Order,
                        ParentSection = parent_section
                    });

                parent_section.ChildSections.Sort((a, b) => Comparer<double>.Default.Compare(a.Order, b.Order));
            }

            parent_Sections_views.Sort((a, b) => Comparer<double>.Default.Compare(a.Order, b.Order));

            return parent_Sections_views;
        }
    }
}
