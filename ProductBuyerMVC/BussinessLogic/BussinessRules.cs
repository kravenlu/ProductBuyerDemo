using ProductBuyerMVC.Data;
using ProductBuyerMVC.Models;

namespace ProductBuyerMVC.BussinessLogic
{
    public class BussinessRules
    {
        private ProductBuyerDataByAPI _apidata;

        public BussinessRules()
        {
            _apidata = new ProductBuyerDataByAPI();
        }
        public bool VerifyProductSKU(string productSKU)
        {
            if (_apidata.GetProductBySKU(productSKU))
            { return false; }
            else
            { return true; }
        }
        public List<BuyerViewModel> GetBuyers()
        {
            return _apidata.GetBuyers();
        }
            public List<ProductViewModel> GetProducts()
        {
            List<ProductModel> products = _apidata.GetProducts();
            List<ProductViewModel> productsview = new List<ProductViewModel>();
            foreach (ProductModel product in products)
            {
                ProductViewModel productviewitem = new ProductViewModel();
                productviewitem.ProductId = product.ProductId;
                productviewitem.SKU = product.SKU;
                productviewitem.Title = product.Title;
                productviewitem.Description = product.Description;
                productviewitem.BuyerId = product.BuyerId;
                productviewitem.BuyerName = product.BuyerName;
                productviewitem.IsActive = product.IsActive;
                productviewitem.UpdatedBy = product.UpdatedBy;
                productviewitem.UpdatedDate = product.UpdatedDate;
                productsview.Add(productviewitem);
            }
            return productsview;
        }
        public ProductViewModel GetProduct(int productid)
        {
            ProductModel product = _apidata.GetProduct(productid);
            ProductViewModel productview = new ProductViewModel()
            {
                ProductId = product.ProductId,
                SKU = product.SKU,
                Title = product.Title,
                Description = product.Description,
                BuyerId = product.BuyerId,
                BuyerName = product.BuyerName,
                IsActive = product.IsActive,
                UpdatedBy = product.UpdatedBy,
                UpdatedDate = product.UpdatedDate
            };
            return productview;
        }
        public bool AddProduct(ProductViewModel productview)
        {
            ProductModel product = new ProductModel()
            {
                SKU = productview.SKU,
                Title = productview.Title,
                Description = productview.Description,
                BuyerId = productview.BuyerId,
                IsActive = productview.IsActive,
                UpdatedBy = productview.UpdatedBy,
                UpdatedDate = productview.UpdatedDate
            };
            if (_apidata.AddProduct(product))
            { return true; }
            else
            { return false; }
        }
        public ProductViewModelForUpdate GetProductForUpdate(int productid)
        {
            ProductModel product = _apidata.GetProduct(productid);
            ProductViewModelForUpdate productview = new ProductViewModelForUpdate()
            {
                ProductId = product.ProductId,
                SKU = product.SKU,
                Title = product.Title,
                Description = product.Description,
                BuyerId = product.BuyerId,
                IsActive = product.IsActive,
                UpdatedBy = product.UpdatedBy,
                Message = product.Message
            };
            return productview;
        }
        public string UpdateProduct(ProductViewModelForUpdate productview)
        {
            //Reload the product data from data source. Compare to view data and notify buyer.
            string sMessage = string.Empty;
            INotify notify = new NotifyToPage();

            ProductModel product = _apidata.GetProduct(productview.ProductId);
            if (product != null) {
                if (productview.BuyerId != product.BuyerId)
                {
                    if (productview.IsActive != product.IsActive)
                    {
                        if (!productview.IsActive)
                            sMessage = "The product " + productview.SKU + " has been de-actived. ";
                    }
                    sMessage = notify.Notification(productview.BuyerId.ToString(), "Buyer has been changed. ");
                    sMessage = sMessage + notify.Notification(product.BuyerId.ToString(), "Buyer has been changed. ");

                    
                }
                else if (productview.IsActive != product.IsActive)
                {
                    if (!productview.IsActive)
                        sMessage = "The product" + productview.SKU + " has been de-actived.";
                }
            }
            
            // Save the product
            ProductModel productupdate = new ProductModel()
            {
                ProductId = productview.ProductId,
                SKU = productview.SKU,
                Title = productview.Title,
                Description = productview.Description,
                BuyerId = productview.BuyerId,
                IsActive = productview.IsActive,
                UpdatedBy = productview.UpdatedBy,
                Message = productview.Message
            };
            if (_apidata.UpdateProduct(productupdate))
            {
                return sMessage + "Save succeed.";
            }
            else
            { return sMessage; }
        }

        public bool DeleteProduct(int productid)
        {
            if (_apidata.DeleteProduct(productid))
            { return true; }
            else
            { return false; }
        }
    }
}
