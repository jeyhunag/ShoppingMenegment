using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingMenegment.Models.Entity
{
    public partial class Product : BaseEntity
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Orderitems = new HashSet<Orderitem>();
        }

        public string Model { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int UnitPrice { get; set; }

        public string Img { get; set; } = null!;
        [NotMapped]
        public IFormFile file { get; set; }

        public int ProductCategoryId { get; set; }

        public ProductCategory? ProductCategory { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Orderitem> Orderitems { get; set; }
    }
}
