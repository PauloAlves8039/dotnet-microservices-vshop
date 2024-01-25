using Microsoft.AspNetCore.Mvc;
using VShop.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using VShop.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace VShop.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            CartViewModel? cartViewModel = await GetCartByUser();

            if (cartViewModel is null)
            {
                ModelState.AddModelError("CartNotFound", "Does not exist a cart yet...Come on Shopping...");
                return View("/Views/Cart/CartNotFound.cshtml");
            }

            return View(cartViewModel);
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            var result = await _cartService.RemoveItemFromCartAsync(id, await GetAccessToken());

            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(id);
        }

        private async Task<CartViewModel?> GetCartByUser() 
        {
            var cart = await _cartService.GetCartByUserIdAsync(GetUserId(), await GetAccessToken());

            if (cart?.CartHeader is not null)
            {
                foreach (var item in cart.CartItems)
                {
                    cart.CartHeader.TotalAmount += (item.Product.Price * item.Quantity);
                }
            }
            return cart;
        }

        private async Task<string> GetAccessToken()
        {
            return await HttpContext.GetTokenAsync("access_token");
        }

        private string GetUserId()
        {
            return User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
        }
    }
}
