using System.ComponentModel.DataAnnotations;

namespace ShoppingMenegment.Models.Entity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow.AddHours(24);

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

    }
}
