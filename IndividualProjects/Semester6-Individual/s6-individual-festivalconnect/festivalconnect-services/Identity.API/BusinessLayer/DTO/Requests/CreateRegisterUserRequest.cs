﻿using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTO.Requests
{
    public class CreateRegisterUserRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required, Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
        [Required]
        public int RoleId { get; set; }
    }
}
