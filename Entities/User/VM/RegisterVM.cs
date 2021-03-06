﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Entities.User.VM
{
    public class RegisterVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 1, ErrorMessage = "Length must be in between 1 and 32")]
        public string Password { get; set; }

        public IdentityUser GetUser()
        {
            var user = new IdentityUser
            {
                UserName = Username,
                Email = Email,
            };

            return user;

        }
    }
}
