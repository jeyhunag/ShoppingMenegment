using System;
using System.Collections.Generic;

namespace ShoppingMenegment.Models.Entity
{
    public partial class Orderitem: BaseEntity
    {
        public int ProductCount { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public  Order? Order { get; set; }
        public  Product? Product { get; set; }
    }
}
