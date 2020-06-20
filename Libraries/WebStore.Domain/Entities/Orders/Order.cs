using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities.Orders
{
    public class Order : NamedEntity
    {
        [Required]
        public virtual Identity.User User { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
