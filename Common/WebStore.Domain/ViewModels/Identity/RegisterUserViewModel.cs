using System.ComponentModel.DataAnnotations;

namespace WebStore.Domain.ViewModels.Identity
{
    public class RegisterUserViewModel
    {
        [Required]
        [MaxLength(256)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password confirmation")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
