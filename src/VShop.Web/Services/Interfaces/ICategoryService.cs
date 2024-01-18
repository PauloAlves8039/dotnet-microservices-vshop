using VShop.Web.Models;

namespace VShop.Web.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();
    }
}
