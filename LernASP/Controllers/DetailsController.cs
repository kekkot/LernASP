using LernASP.data.Interface;
using LernASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LernASP.Controllers
{
    public class DetailsController : Controller //Класс содержит различные методы, возвращающие html страницы
    {
        private readonly IAllDetails _allDetails; //Обращаемся не то, чтобы к интерфейсу, а к классу который реализует этот интерфейс
        private readonly IdetailsCategory _allCategory;

        public DetailsController(IAllDetails iAllDetails, IdetailsCategory iDetailsCategory) //Передаем не только интерфейс, а еще и класс который является реализатором
        {
            _allDetails = iAllDetails;
            _allCategory = iDetailsCategory;
        }

        public ViewResult List() //При обращении к List получаем html страницу
        {
            /*ViewBag.Category = "Some New";//Вьюбек сам передается на страницу, не рекомендуется
            var details = _allDetails.details*/
            ViewBag.Title = "Страница с запчастями";
            DetailsListViewModel obj = new DetailsListViewModel();
            obj.GetAllDetails = _allDetails.details;
            obj.CurrCategory = "Автохимия";

            return View(obj);//До вывода страницы, передаем объект со всеми товарами на сайте
        }
    }
}
