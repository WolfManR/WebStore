using System;
using System.ComponentModel.DataAnnotations;

using WebStore.Domain;

namespace WebStore.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя не указано, обязательно к заполнению")]
        [Display(Name = "Имя")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "должно быть от 2-ух до 200 символов")]
        public string Firstname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия не указана, обязательно к заполнению")]
        [Display(Name = "Фамилия")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "должно быть от 2-ух до 200 символов")]
        public string Surname { get; set; }
        public string AvatarUrl { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Возраст не указано, обязательно к заполнению")]
        [Display(Name = "Возраст")]
        [Range(18,75)]
        public int Age { get; set; }

        public Sex Sex { get; set; }
        public DateTime Birthday { get; set; }

        public string Name { get => $"{Firstname} {Surname}"; }
    }
}
