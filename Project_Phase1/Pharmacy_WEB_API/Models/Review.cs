//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pharmacy_WEB_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int ReviewID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<decimal> Rating { get; set; }
        public string ReviewComments { get; set; }
        public Nullable<System.DateTime> ReviewDate { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
