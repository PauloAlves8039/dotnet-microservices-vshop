using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VShop.DiscountApi.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }

        [StringLength(30)]
        public string? CouponCode { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Discount { get; set; }
    }
}
