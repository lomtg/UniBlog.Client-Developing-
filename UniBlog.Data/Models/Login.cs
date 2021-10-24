using System;
using System.Collections.Generic;
using System.Text;

namespace UniBlog.Data.Models
{
    public class Login
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}
