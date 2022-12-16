using ShoppingMenegment.Models.Entity.Identity;

namespace ShoppingMenegment.Models.Entity
{
    public class Basket :BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
  
    }
}
