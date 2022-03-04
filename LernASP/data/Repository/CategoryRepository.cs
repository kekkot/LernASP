using LernASP.data.Interface;
using LernASP.data.Internal_models;

namespace LernASP.data.Repository
{
    public class CategoryRepository : IdetailsCategory
    {
        private readonly AppDBContent addDBContent;

        public CategoryRepository(AppDBContent addDBContent)
        {
            this.addDBContent = addDBContent;
        }
        public IEnumerable<Category> AllCategories => addDBContent.Categories; //Получить все категории
    }
}
