using LernASP.data.Internal_models;
using LernASP.data.Repository;
using LernASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LernASP.Controllers
{
    public class ShopCartController :Controller
    {
        private readonly DetailRepository _detailRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(DetailRepository detailRepository, ShopCart shopCart)
        {
            _detailRep = detailRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var item = _shopCart.GetShopItems();
            _shopCart.ListShopItems = item;

            var obj = new ShopCartViewModel { shopCart = _shopCart };

            return View(obj);
        }

        public RedirectToActionResult AddtoCart(int id) { 
        
        }
    }
}
