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
        public List<ShopCart> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId};
        }

        public void AddToCart(Detail detail, int amout)
        {
            appDBContent.CartItems.Add(new CartItem
            {
                ShopCartId = ShopCartId,
                detail = detail,
                price = detail.Price
            });
            appDBContent.SaveChanges();
        }

        public List<CartItem> GetShopItems()
        {
            return appDBContent.CartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.detail).ToList();
        }

    }
}
