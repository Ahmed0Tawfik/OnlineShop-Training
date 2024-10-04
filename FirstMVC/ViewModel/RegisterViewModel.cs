﻿using System.ComponentModel.DataAnnotations;

namespace FirstMVC.ViewModel
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "Confirmed Password")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }

        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
