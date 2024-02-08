using DataAccess.DBProvider;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ProductBuyerData : IProductBuyerData
    {
        private readonly IDBDataProvider _db;

        public ProductBuyerData(IDBDataProvider db)
        {
            _db = db;
        }
        public Task<IEnumerable<ProductModel>> GetProducts() =>
            _db.GetData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { });

        public async Task<ProductModel?> GetProduct(int productid)
        {
            var results = await _db.GetData<ProductModel, dynamic>("dbo.spProduct_Get", new { ProductId = productid });
            return results.FirstOrDefault();
        }
        public async Task<ProductModel?> GetProductBySKU(string sku)
        {
            var results = await _db.GetData<ProductModel, dynamic>("dbo.spProduct_GetBySKU", new { SKU = sku });
            return results.FirstOrDefault();
        }
        public Task AddProduct(ProductModel product) =>
            _db.SaveData("dbo.spProduct_Insert", new { product.SKU, product.Title, product.Description, product.BuyerId, product.IsActive, product.UpdatedBy });

        public Task UpdateProduct(ProductModel product) =>
            _db.SaveData("dbo.spProduct_Update", new { product.ProductId, product.SKU, product.Title, product.Description, product.BuyerId, product.IsActive, product.UpdatedBy, product.Message });

        public Task DeleteProduct(int productid) =>
            _db.SaveData("dbo.spProduct_Delete", new { ProductId = productid });

        public Task<IEnumerable<BuyerModel>> GetBuyers() =>
            _db.GetData<BuyerModel, dynamic>("dbo.spBuyer_GetAll", new { });
    }
}
