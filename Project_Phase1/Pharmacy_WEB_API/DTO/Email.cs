using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy_WEB_API.DTO
{
    public class Email
    {
        public String to { get; set; }
        public String subject { get; set; }
        public String message { get; set; }

    }
}