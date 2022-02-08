namespace LernASP.data.Internal_models
{
    public class Category //Категории товара
    {
        public int Id { get; set; } //Id категории
        public string Name { get; set; } //Название категории

        public string Description { get; set; } //Описание категории

        public List<Detail> Details { get; set; } //Какие товары входят в эту категорию
    }
}
