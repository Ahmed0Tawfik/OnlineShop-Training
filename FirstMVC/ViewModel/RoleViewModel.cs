﻿using System.ComponentModel.DataAnnotations;

namespace FirstMVC.ViewModel
{
    public class RoleViewModel
    {
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
