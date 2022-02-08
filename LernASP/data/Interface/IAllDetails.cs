using LernASP.data.Internal_models;

namespace LernASP.data.Interface
{
    public interface IAllDetails
    {
        IEnumerable<Detail> details { get; } //Для вывода всех товаров
        IEnumerable<Detail> getFavDetails { get; set; }
        Detail getObjectDetail(int detailId);

    }
}
