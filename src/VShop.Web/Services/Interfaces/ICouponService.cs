using VShop.Web.Models;

namespace VShop.Web.Services.Interfaces
{
    public interface ICouponService
    {
        Task<CouponViewModel> GetDiscountCoupon(string couponCode, string token);
    }
}
