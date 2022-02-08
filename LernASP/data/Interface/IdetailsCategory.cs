using LernASP.data.Internal_models;

namespace LernASP.data.Interface
{
    public interface IdetailsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
