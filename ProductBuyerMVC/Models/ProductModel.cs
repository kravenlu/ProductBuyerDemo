using System.ComponentModel.DataAnnotations;

namespace ProductBuyerMVC.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Required]
        public string? SKU { get; set; }
        [Required] 
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int BuyerId { get; set; }
        public string? BuyerName { get; set; }
        public bool IsActive { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? Message { get; set; }
    }
}
