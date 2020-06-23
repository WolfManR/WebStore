using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Domain.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name not specified, required")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "must be from 2 to 200 characters")]
        public string Firstname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname not indicated, required")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "must be from 2 to 200 characters")]
        public string Surname { get; set; }
        public string AvatarUrl { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Age not specified, required")]
        [Range(18, 75)]
        public int Age { get; set; }

        public Sex Sex { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        public string Name { get => $"{Firstname} {Surname}"; }
    }
}
