using System;
using System.ComponentModel.DataAnnotations;

using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    public class Employee : BaseEntity
    {
        [Required]
        [MinLength(2), MaxLength(200)]
        public string Firstname { get; set; }

        [Required]
        [MinLength(2), MaxLength(200)]
        public string Surname { get; set; }

        public string AvatarUrl { get; set; }

        [Range(18, 75)]
        public int Age { get; set; }

        public Sex Sex { get; set; }
        public DateTime BirthdayDate { get; set; }
    }
}
