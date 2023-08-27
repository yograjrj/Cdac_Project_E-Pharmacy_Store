//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_Phase1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> ManufacturerID { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> QuantityInStock { get; set; }
        public Nullable<System.DateTime> ManufacturingDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string Image { get; set; }
    }
}