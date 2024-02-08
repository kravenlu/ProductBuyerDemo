using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductBuyerMVC.BussinessLogic;
using ProductBuyerMVC.Models;

namespace ProductBuyerMVC.Controllers
{
    public class BuyerController : Controller
    {
        private BussinessRules _rules;
        public BuyerController()
        {
            _rules = new BussinessRules();
        }
        [HttpGet]
        public IActionResult ListBuyers()
        {
            List<BuyerViewModel> buyers = _rules.GetBuyers();
            return View(buyers);
        }
   
    }
}
