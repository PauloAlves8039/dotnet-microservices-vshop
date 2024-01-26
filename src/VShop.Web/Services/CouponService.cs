using System.Net.Http.Headers;
using System.Text.Json;
using VShop.Web.Models;
using VShop.Web.Services.Interfaces;

namespace VShop.Web.Services
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly JsonSerializerOptions? _options;
        private const string apiEndpoint = "/api/coupon";
        private CouponViewModel couponViewModel = new CouponViewModel();

        public CouponService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<CouponViewModel> GetDiscountCoupon(string couponCode, string token)
        {
            var client = _clientFactory.CreateClient("DiscountApi");
            PutTokenInHeaderAuthorization(token, client);

            using (var response = await client.GetAsync($"{apiEndpoint}/{couponCode}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    couponViewModel = await JsonSerializer.DeserializeAsync<CouponViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return couponViewModel;
        }

        private static void PutTokenInHeaderAuthorization(string token, HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
