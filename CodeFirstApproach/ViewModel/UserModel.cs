﻿using System.ComponentModel.DataAnnotations;

namespace LibraryManagementProject.ViewModel
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty ;

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
    }
}
