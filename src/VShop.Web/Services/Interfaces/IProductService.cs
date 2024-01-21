using VShop.Web.Models;

namespace VShop.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProducts(string token);
        Task<ProductViewModel> FindProductById(int id, string token);
        Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel, string token);
        Task<ProductViewModel> UpdateProduct(ProductViewModel productViewModel, string token);
        Task<bool> DeleteProductById(int id, string token);
    }
}
