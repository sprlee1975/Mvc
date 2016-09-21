using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootHelloWord.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "不可為空")]
        [Display(Name = "用戶")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "不可為空")]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        public bool IsRememberMe { get; set; }
    }
}