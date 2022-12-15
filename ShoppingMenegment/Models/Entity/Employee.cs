using ShoppingMenegment.Models.Entity.Identity;
using System;
using System.Collections.Generic;

namespace ShoppingMenegment.Models.Entity
{
    public partial class Employee : BaseEntity
    {
       
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
