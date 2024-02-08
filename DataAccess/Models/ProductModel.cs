using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public required string SKU { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int BuyerId { get; set; }
        public string? BuyerName { get; set; }
        public bool IsActive { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? Message { get; set; }
    }
    
}
