using System;

namespace WebStore.Domain.ViewModels
{
    public class PageViewModel
    {
        public int TotalItems { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int TotalPages
        {
            get
            {
                var integer = (int) Math.Ceiling((decimal) TotalItems / PageSize);
                var module = (int)Math.Ceiling((decimal)TotalItems % PageSize);
                return module < PageSize ? integer+1 : integer;
            }
        }
    }
}