using LernASP.data.Interface;
using LernASP.data.Internal_models;

namespace LernASP.data.mocks
{
    public class MockCategory : IdetailsCategory
    {
        public IEnumerable<Category> AllCategories //Реализация интерфейса
        {
            get 
            {
                return new List<Category> //Какие категории будут возвращаться при вызове метода AllCategories
                {
                    new Category{ Name = "Автохимия"},
                    new Category{ Name = "Шины и диски"},
                    new Category{ Name = "Автоэлектроника"},
                    new Category{ Name = "Аксессуары"},
                    new Category{ Name = "Электрооборудование"},
                    new Category{ Name = "Инструменты"},
                    new Category{ Name = "Багажные системы"},
                    new Category{ Name = "Средства безопасности"}

                };
            }
        }
    }
}
