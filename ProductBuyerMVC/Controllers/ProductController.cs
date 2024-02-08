using Microsoft.AspNetCore.Mvc;
using ProductBuyerMVC.Models;
using ProductBuyerMVC.BussinessLogic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductBuyerMVC.Controllers
{
    public class ProductController : Controller
    {
        private BussinessRules _rules;
        public ProductController()
        {
            _rules = new BussinessRules();
        }

        [HttpGet]
        public IActionResult ListProducts()
        {
            List<ProductViewModel> products = _rules.GetProducts();
            return View(products);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifySKU(string sku)
        {
            if (!_rules.VerifyProductSKU(sku))
            {
                return Json($"Product SKU {sku} is already in use.");
            }

            return Json(true);
        }
        [NonAction]
        private void GetBuyers()
        {
            var buyers = _rules.GetBuyers();
            ViewBag.Buyers = new SelectList(buyers, "BuyerId", "BuyerName");
        }
        public ActionResult Create()
        {
            GetBuyers();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel product)
        {
            // Attach Validation Error Message to the Model on validation failure.
            if (product.SKU == product.Title)
            {
                ModelState.AddModelError(nameof(product.Title), "Title can't be the same as Product SKU.");
            }
            
            if (ModelState.IsValid)
            {
                if (_rules.AddProduct(product))
                {
                    return RedirectToAction("ListProducts");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            ProductViewModel product = _rules.GetProduct(id);
            return View(product);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null) { return NotFound(); }

            ProductViewModelForUpdate product = _rules.GetProductForUpdate(id.Value);
            
            if (product != null)
            {
                GetBuyers();
                return View(product);
            }
            else { return NotFound(); }
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModelForUpdate viewproduct)
        {
            ViewBag.Message = _rules.UpdateProduct(viewproduct);

            //return RedirectToAction("ListProducts", "Product");

            return View(viewproduct);
        }

        [HttpPost]
        public ActionResult Delete(ProductViewModelForUpdate product)
        {
            // need check the data exists or not


            if (_rules.DeleteProduct(product.ProductId))
            {
                return RedirectToAction("ListProducts");
            }
            return View(product);
        }
    }
}
