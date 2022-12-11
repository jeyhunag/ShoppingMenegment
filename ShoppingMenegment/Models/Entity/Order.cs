using System;
using System.Collections.Generic;

namespace ShoppingMenegment.Models.Entity
{
    public partial class Order: BaseEntity
    {
        public Order()
        {
            Orderitems = new HashSet<Orderitem>();
        }

        public DateTime OrderDate { get; set; }
        public string Address { get; set; } = null!;
        public int CustomerId { get; set; }

        public  Customer? Customer { get; set; } = null!;
        public  ICollection<Orderitem>? Orderitems { get; set; }
    }
}
