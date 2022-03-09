using Microsoft.EntityFrameworkCore;

namespace LernASP.data.Internal_models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent addDBContent)
        {
            this.appDBContent = addDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId};
        }

        public void AddToCart(Detail detail)
        {
            appDBContent.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                detail = detail,
                price = detail.Price
            });
            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return appDBContent.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.detail).ToList();
        }

    }
}
