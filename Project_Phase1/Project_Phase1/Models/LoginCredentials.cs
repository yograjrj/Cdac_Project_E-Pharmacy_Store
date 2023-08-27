using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace Project_Phase1.Models
{
    public class LoginCredentials : Attribute
    {
        public string username { get; set; }
        public string password { get; set; }

    }
}