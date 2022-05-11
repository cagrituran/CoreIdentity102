﻿using System.ComponentModel.DataAnnotations;

namespace CoreIdentity102.ViewModel
{
    public class LoginViewModel
    {
        [Required]
       
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
