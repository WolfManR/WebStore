using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Domain.ViewModels.Identity
{
    public class RegisterUserViewModel
    {
        [Required]
        [MinLength(3,ErrorMessage = "Minimal length 3 characters")]
        [MaxLength(256)]
        [Remote("IsNameFree", "Account")]
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
