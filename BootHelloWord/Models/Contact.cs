﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootHelloWord.Models
{
    public class Contact
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
    }
}