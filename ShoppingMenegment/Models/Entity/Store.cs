using System;
using System.Collections.Generic;

namespace ShoppingMenegment.Models.Entity
{
    public partial class Store: BaseEntity
    {
        public Store()
        {
            Branches = new HashSet<Branch>();
        }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Branch> Branches { get; set; }
    }
}
