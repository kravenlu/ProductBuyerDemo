using Newtonsoft.Json;
using ProductBuyerMVC.Models;
using System.Text;

namespace ProductBuyerMVC.Data
{
    public class ProductBuyerDataByAPI
    {
        Uri baseAddress = new Uri("https://localhost:7023");
        private readonly HttpClient _httpClient;

        public ProductBuyerDataByAPI()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public List<BuyerViewModel> GetBuyers()
        {
            List<BuyerViewModel> buyers = new List<BuyerViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Buyers").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                buyers = JsonConvert.DeserializeObject<List<BuyerViewModel>>(data);
            }
            return buyers;
        }
        public List<ProductModel> GetProducts()
        {
            List<ProductModel> products = new List<ProductModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Products").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductModel>>(data);
            }
            return products;
        }
        public ProductModel GetProduct(int productid)
        {
            ProductModel product = new ProductModel();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Products/" + productid).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductModel>(data);
            }
            return product;
        }
        public bool GetProductBySKU(string sku)
        {
            ProductViewModel product = new ProductViewModel();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Product/" + sku).Result;

            if (response.IsSuccessStatusCode)
            { return true; }
            else
            { return false; }
        }
        public bool AddProduct(ProductModel product)
        {
            string data = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "Products", content).Result;
            if (response.IsSuccessStatusCode)
            { return true; }
            else
            { return false; }
        }
        public bool UpdateProduct(ProductModel product)
        {
            string dataupdate = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(dataupdate, Encoding.UTF8, "application/json");
            HttpResponseMessage responseupdate = _httpClient.PutAsync(_httpClient.BaseAddress + "Products", content).Result;
            if (responseupdate.IsSuccessStatusCode)
            { return true; }
            else
            { return false; }
        }

        public bool DeleteProduct(int productid)
        {
            HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "Products?productid=" + productid).Result;
            if (response.IsSuccessStatusCode)
            { return true; }
            else
            { return false; }
        }

    }
}
