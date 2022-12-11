using ShoppingMenegment.Models.Entity;
using System.Collections.Generic;

namespace ShoppingMenegment.Models.DataViewModel
{
    public class DataViewModel
    {
        public IEnumerable<Branch> branches { get; set; }
        public IEnumerable<Store> stores { get; set; }
        public IEnumerable<Cart> carts { get; set; }
        public IEnumerable<Customer> customers { get; set; }
        public IEnumerable<Employee> employees { get; set; }
        public IEnumerable<Order> orders { get; set; }
        public IEnumerable<Orderitem> orderitems { get; set; }
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<ProductCategory> productCategories { get; set; }

    }
}
