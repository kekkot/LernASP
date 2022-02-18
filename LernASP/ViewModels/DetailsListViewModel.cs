using LernASP.data.Internal_models;

namespace LernASP.ViewModels
{
    public class DetailsListViewModel
    {
        public IEnumerable<Detail> GetAllDetails { get; set; }

        public string  CurrCategory { get; set; }

    }
}
