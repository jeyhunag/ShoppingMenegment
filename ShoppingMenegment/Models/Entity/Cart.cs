using System;
using System.Collections.Generic;

namespace ShoppingMenegment.Models.Entity
{
    public partial class Cart: BaseEntity
    {
        public int ProductCount { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public  Customer? Customer { get; set; } = null!;
        public  Product? Product { get; set; } = null!;
    }
}
