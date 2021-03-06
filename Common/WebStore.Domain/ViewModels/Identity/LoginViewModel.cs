﻿using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace WebStore.Domain.ViewModels.Identity
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(256)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me!")]
        public bool RememberMe { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }
    }
}
