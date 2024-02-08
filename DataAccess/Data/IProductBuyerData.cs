using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IProductBuyerData
    {
        Task AddProduct(ProductModel product);
        Task DeleteProduct(int productid);
        Task<IEnumerable<BuyerModel>> GetBuyers();
        Task<ProductModel?> GetProduct(int productid);
        Task<ProductModel?> GetProductBySKU(string sku);
        Task<IEnumerable<ProductModel>> GetProducts();
        Task UpdateProduct(ProductModel product);
    }
}