//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLHOLIDAYPARTY.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dish
    {
        public int DishID { get; set; }
        public string PersonName { get; set; }
        public string PhoneNumber { get; set; }
        public string DishName { get; set; }
        public string DishDescription { get; set; }
        public string Options { get; set; }
        public Nullable<int> guestID { get; set; }
    
        public virtual Guest Guest { get; set; }
    }
}
