//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pharmacy_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.CancelMessages = new HashSet<CancelMessage>();
            this.Payments = new HashSet<Payment>();
            this.Tables = new HashSet<Table>();
        }
    
        public int OrderID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> AddressID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public string OrderPrice { get; set; }
    
        public virtual Address Address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CancelMessage> CancelMessages { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table> Tables { get; set; }
    }
}
