using System.Diagnostics.CodeAnalysis;

namespace ProductBuyerAPI
{
    public static class WebApi
    {
        public static void ConfigureWebApi(this WebApplication application)
        {
            //webapi endpoint mapping
            application.MapGet("/Products", GetProducts);
            application.MapGet("/Products/{productid}", GetProduct);
            application.MapGet("/Product/{SKU}", GetProductBySKU);
            application.MapPost("/Products", AddProduct);
            application.MapPut("/Products", UpdateProduct);
            application.MapDelete("/Products", DeleteProduct);

            application.MapGet("/Buyers", GetBuyers);
        }

        private static async Task<IResult> GetProducts(IProductBuyerData data)
        {
            try
            {
                return Results.Ok(await data.GetProducts());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetBuyers(IProductBuyerData data)
        {
            try
            {
                return Results.Ok(await data.GetBuyers());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetProduct(int productid, IProductBuyerData data)
        {
            try
            {
                var results = await data.GetProduct(productid);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult?> GetProductBySKU(string SKU, IProductBuyerData data)
        {
            try
            {
                var results = await data.GetProductBySKU(SKU);
                if (results == null) return null; // Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult>  AddProduct(ProductModel product, IProductBuyerData data)
        {
            try
            {
                await data.AddProduct(product);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> UpdateProduct(ProductModel product, IProductBuyerData data)
        {
            try
            {
                await data.UpdateProduct(product);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> DeleteProduct(int productid, IProductBuyerData data)
        {
            try
            {
                await data.DeleteProduct(productid);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

    }
}
