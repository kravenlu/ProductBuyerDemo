using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductBuyerMVC.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Product SKU")]
        [Remote(action: "VerifySKU", controller: "Product")]
        public string? SKU { get; set; }
        [Required]
        [StringLength(50)]
        public string? Title { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "Buyer ID")]
        public int BuyerId { get; set; }
        [Display(Name = "Buyer Name")]
        public string? BuyerName { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Updated By")]
        public int UpdatedBy { get; set; }
        [Display(Name = "Updated Date")]
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }
    }
    public class ProductViewModelForUpdate
    {
        public int ProductId { get; set; }
        [Required]
        public string? SKU { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required] 
        public int BuyerId { get; set; }
        public bool IsActive { get; set; }
        public int UpdatedBy { get; set; }
        public string? Message { get; set; }
    }
}
