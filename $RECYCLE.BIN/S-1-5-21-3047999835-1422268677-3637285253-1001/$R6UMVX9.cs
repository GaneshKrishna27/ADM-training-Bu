using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forms.Models
{
    public class User
    {
        [Key]
        public string uId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "User name required")]
        public string uName { get; set; }
        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string uPwd { get; set; }
        [Required(ErrorMessage = "Enter email")]
        [DataType(DataType.EmailAddress)]
        public string uEmail { get; set; }
        [Required(ErrorMessage = "Enter phnno")]
        public string phnNo { get; set; }
    }
}