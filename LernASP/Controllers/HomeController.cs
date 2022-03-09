using LernASP.data.Interface;
using LernASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LernASP.Controllers
{
    public class HomeController : Controller
    {
        private IAllDetails _detailRep;

        public HomeController(IAllDetails detailRepository)
        {
            _detailRep = detailRepository;
        }
        public ViewResult Index()
        {
            var homeDetails = new HomeViewModel
            {
                favDetails = _detailRep.getFavDetails
            };
            return View(homeDetails);
        }
    }
}
