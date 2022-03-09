namespace LernASP.data.Internal_models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Detail? detail { get; set; }
        public int price { get; set; }

        public string ShopCartId { get; set; } = "1";
    }
}
