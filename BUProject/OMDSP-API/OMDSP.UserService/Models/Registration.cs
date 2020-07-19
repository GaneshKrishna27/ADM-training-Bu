using System;
using System.Collections.Generic;

namespace OMDSP.UserService.Models
{
    public partial class Registration
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
