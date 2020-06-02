using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя не указано, обязательно к заполнению")]
        [Display(Name = "Имя")]
        [StringLength(maximumLength: 200, MinimumLength = 2,ErrorMessage ="должно быть от 2-ух до 200 символов")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия не указана, обязательно к заполнению")]
        [Display(Name = "Фамилия")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "должно быть от 2-ух до 200 символов")]
        public string Surname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Отчество не указано, обязательно к заполнению")]
        [Display(Name = "Отчество")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "должно быть от 2-ух до 200 символов")]
        public string Patronymic { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Возраст не указано, обязательно к заполнению")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }
    }
}
