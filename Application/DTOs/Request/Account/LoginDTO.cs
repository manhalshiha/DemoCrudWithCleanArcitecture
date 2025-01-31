﻿using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request.Account
{
    public class LoginDTO
    {
        [EmailAddress,Required]
        [RegularExpression("[^@ \\t\\r\\n]+@[^@ \\t\\r\\n]+\\.[^@ \\t\\r\\n]+",ErrorMessage ="Your email is not valid, provide email such as @google , @yahoo , @hotmail.")]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage ="Your password must be a mix of alphanumeric and special characters")]
        public string Password { get; set; } = string.Empty;
    }
}
