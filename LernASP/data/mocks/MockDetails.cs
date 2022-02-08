using LernASP.data.Interface;
using LernASP.data.Internal_models;

namespace LernASP.data.mocks
{
    public class MockDetails : IAllDetails
    {
        private readonly IdetailsCategory _idetalsCategory = new MockCategory();
        public IEnumerable<Detail> details 
        { get
            {
                return new List<Detail> //Список всех товаров
                { new Detail{
                    Name = "Nordman SX 2", 
                    Price = 4500,
                    ShortDescription = "Шины летник",
                    IsFavorite= true,
                    Category = (Category)_idetalsCategory.AllCategories.Where(e => e.Name=="Шины и диски")},

                new Detail{
                    Name = "Formula F 5W-30",
                    Price = 2500,
                    ShortDescription = "Моторное масло синтетика",
                    IsFavorite= true,
                    Category = (Category)_idetalsCategory.AllCategories.Where(e => e.Name=="Автохимия")},

                new Detail{
                    Name = "MYSTERY MNS-410MP",
                    Price = 3000,
                    ShortDescription = "Навигатор спутниковый",
                    IsFavorite= true,
                    Category = (Category)_idetalsCategory.AllCategories.Where(e => e.Name=="Автоэлектроника")},

                new Detail{
                    Name = "Little Trees",
                    Price = 95,
                    ShortDescription = "Ароматизатор Ёлочка",
                    IsFavorite= true,
                    Category = (Category)_idetalsCategory.AllCategories.Where(e => e.Name=="Аксессуары")}

                };
            }
        }
        public IEnumerable<Detail> getFavDetails { get; set; }

        public Detail getObjectDetail(int detailId)
        {
            throw new NotImplementedException();
        }
    }
}
