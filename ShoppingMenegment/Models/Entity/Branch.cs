using System;
using System.Collections.Generic;

namespace ShoppingMenegment.Models.Entity
{
    public partial class Branch: BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public int StoreId { get; set; }

        public  Store? Store { get; set; } = null!;
    }
}
