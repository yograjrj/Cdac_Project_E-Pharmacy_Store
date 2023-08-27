using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy_WEB_API.DTO
{
    public class ChangePass
    {
        public String newPassword { get; set; }
        public String oldPassword { get; set; }
    }
}