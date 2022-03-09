using LernASP.data.Internal_models;
using LernASP.data.Interface;
using LernASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LernASP.Controllers
{
    public class ShopCartController :Controller
    {
        private IAllDetails _detailRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllDetails detailRepository, ShopCart shopCart)
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

        public RedirectToActionResult AddtoCart(int id)//Переадресация на другу стр 
        {
            var item = _detailRep.details.FirstOrDefault(i => i.Id == id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
