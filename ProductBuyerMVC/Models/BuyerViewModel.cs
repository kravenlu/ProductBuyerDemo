using System.ComponentModel.DataAnnotations;

namespace ProductBuyerMVC.Models
{
    public class BuyerViewModel
    {
        public int BuyerId { get; set; }
        [Required] 
        public string? BuyerName { get; set; }
        [Required] 
        public string? Email { get; set; }
    }
}
