﻿using System.ComponentModel.DataAnnotations;

namespace MovieApp.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
