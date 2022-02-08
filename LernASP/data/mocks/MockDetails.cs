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
                    ShortDescription = "Шины летние",
                    IsFavorite= true,
                    Category = _idetalsCategory.AllCategories.First()},

                new Detail{
                    Name = "Formula F 5W-30",
                    Price = 2500,
                    ShortDescription = "Моторное масло синтетика",
                    IsFavorite= true,
                    Category = _idetalsCategory.AllCategories.First()},

                new Detail{
                    Name = "MYSTERY MNS-410MP",
                    Price = 3000,
                    ShortDescription = "Навигатор спутниковый",
                    IsFavorite= true,
                    Category = _idetalsCategory.AllCategories.First()},

                new Detail{
                    Name = "Little Trees",
                    Price = 95,
                    ShortDescription = "Ароматизатор Ёлочка",
                    IsFavorite= true,
                    Category = _idetalsCategory.AllCategories.First()}

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
