﻿using System.ComponentModel.DataAnnotations;

namespace Final.Areas.Admin.ViewModels
{
    public class AdminLoginVM
    {
        [Required]
        public string UserName { get; set; }=string.Empty;
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public bool IsPersistent { get; set; }
    }
}
