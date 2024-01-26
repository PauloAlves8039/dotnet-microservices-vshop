using VShop.DiscountApi.DTOs;

namespace VShop.DiscountApi.Repositories.Interfaces
{
    public interface ICouponRepository
    {
        Task<CouponDTO> GetCouponByCode(string couponCode);
    }
}
