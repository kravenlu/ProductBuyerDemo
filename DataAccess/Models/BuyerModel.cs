using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class BuyerModel
    {
        public int BuyerId { get; set; }
        public required string BuyerName { get; set; }
        public required string Email { get; set; }

    }
}
