using Microsoft.Build.Framework;

namespace ShoppingMenegment.Models.Entity
{
    public class Seller:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        public int BranchId { get; set; }

        public Branch? Branch { get; set; }
        public int ContactNumber { get; set; }
    }
}
