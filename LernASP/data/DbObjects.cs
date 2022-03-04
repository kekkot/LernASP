using LernASP.data.Internal_models;

namespace LernASP.data
{
    public class DbObjects
    {
        public static void Initial(AppDBContent content)
        {
            
            if (!content.Categories.Any())
            {
                content.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Details.Any())
            {
                content.AddRange(
                        new Detail
                        {
                            Name = "Nordman SX 2",
                            Price = 4500,
                            ShortDescription = "Шины летние",
                            Img = "/img/Шины.jpeg",
                            IsFavorite = true,
                            Category = Categories["Шины и диски"]
            },
                        new Detail
                        {
                            Name = "Formula F 5W-30",
                            Price = 2500,
                            ShortDescription = "Моторное масло синтетика",
                            Img = "/img/Масло.png",
                            IsFavorite = true,
                            Category = Categories["Автохимия"]
                        },

                        new Detail
                        {
                            Name = "MYSTERY MNS-410MP",
                            Price = 3000,
                            ShortDescription = "Навигатор спутниковый",
                            Img = "/img/Навигатор.jpeg",
                            IsFavorite = true,
                            Category = Categories["Автоэлектроника"]
                        }
                    );
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null) //Пустая ли категория
                {
                    var list = new Category[] //Создаем список и суем туда категории
                    {
                        new Category { Name = "Автохимия" },
                        new Category { Name = "Шины и диски" },
                        new Category { Name = "Автоэлектроника" },
                        new Category { Name = "Аксессуары" },
                        new Category { Name = "Электрооборудование" },
                        new Category { Name = "Инструменты" },
                        new Category { Name = "Багажные системы" },
                        new Category { Name = "Средства безопасности" }
                    };
                    category = new Dictionary<string, Category>(); //Выделяем память
                    foreach (Category el in list) //Перебор элементов и добавляем их в переменную
                    {
                        category.Add(el.Name, el);
                    }
                }
                return category;
            }
        }
    }
}
