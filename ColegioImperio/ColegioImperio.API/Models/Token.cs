using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColegioImperio.API.Models
{
    public class Token
    {
        public string Code { get; set; }
        public string Username { get; set; }
        public DateTime Expires { get; set; }
    }
}