using System;
using System.Collections.Generic;

namespace ShoppingMenegment.Models.Entity
{
    public partial class ProductCategory: BaseEntity
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
