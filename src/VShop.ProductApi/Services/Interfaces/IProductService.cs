using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int id);
        Task AddProduct(ProductDTO productDto);
        Task UpdateProduct(ProductDTO productDto);
        Task RemoveProduct(int id);
    }
}
