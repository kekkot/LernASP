using LernASP.data.Interface;
using LernASP.data.Internal_models;
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

        /*[Route("Details/list")]
        [Route("Details/list/(category)")]*/
        public ViewResult List(string category) //При обращении к List получаем html страницу
        {           
            string _category = category;
            IEnumerable<Detail> details = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                details = _allDetails.details.OrderBy(i => i.Id);
            }
            else
            {
                if(string.Equals("Автохимия", category, StringComparison.OrdinalIgnoreCase))
                {
                    details = _allDetails.details.Where(i => i.Category.Name.Equals("Автохимия"));
                }
                else if(string.Equals("Шины и диски", category, StringComparison.OrdinalIgnoreCase))
                {
                    details = _allDetails.details.Where(i => i.Category.Name.Equals("Шины и диски"));
                }
                currCategory = _category;
            }
            var detailObj = new DetailsListViewModel
            {
                GetAllDetails = details,
                CurrCategory = currCategory
            };


            /*ViewBag.Category = "Some New";//Вьюбек сам передается на страницу, не рекомендуется
            var details = _allDetails.details*/
            ViewBag.Title = "Страница с запчастями";

            return View(detailObj);//До вывода страницы, передаем объект со всеми товарами на сайте
        }
    }
}
