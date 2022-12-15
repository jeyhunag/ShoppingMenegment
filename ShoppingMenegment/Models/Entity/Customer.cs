using ShoppingMenegment.Models.Entity.Identity;
using System;
using System.Collections.Generic;

namespace ShoppingMenegment.Models.Entity
{
    public partial class Customer: BaseEntity
    {
        public Customer()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Gender { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Description { get; set; } = null!;


        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
