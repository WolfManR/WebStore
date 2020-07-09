using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

using WebStore.Domain.Models;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Services.InCookies
{
    public class CookiesCartRepo : ICartRepo
    {
        private readonly IHttpContextAccessor accessor;
        private readonly string cartName;

        public CookiesCartRepo(IHttpContextAccessor httpContextAccessor)
        {
            accessor = httpContextAccessor;

            var user = httpContextAccessor.HttpContext.User;
            var userName = user.Identity.IsAuthenticated ? user.Identity.Name : null;
            cartName = $"WebStore.Cart[{userName}]";
        }

        public Cart Cart
        {
            get
            {
                var context = accessor.HttpContext;
                var cookies = context.Response.Cookies;
                var cartCookie = context.Request.Cookies[cartName];
                if (cartCookie is null)
                {
                    var cart = new Cart();
                    cookies.Append(cartName, JsonConvert.SerializeObject(cart));
                    return cart;
                }

                ReplaceCookie(cookies, cartCookie);
                return JsonConvert.DeserializeObject<Cart>(cartCookie);
            }
            set => ReplaceCookie(accessor.HttpContext.Response.Cookies, JsonConvert.SerializeObject(value));
        }

        private void ReplaceCookie(IResponseCookies cookies, string cookie)
        {
            cookies.Delete(cartName);
            cookies.Append(cartName, cookie);
        }
    }
}
