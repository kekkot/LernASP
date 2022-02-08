namespace LernASP.data.Internal_models
{
    public class Detail //Класс описания детали
    {
        public int Id { get; set; } //Id детали

        public string Name { get; set; } //Название детали

        public short Price { get; set; } //Цена, не должна быть отрицательной

        public string ShortDescription { get; set; } //Короткое описание

        public string LongDescription { get; set; } //Полное описание

        public string Img { get; set; } //Ссылка на картинку

        public bool IsFavorite { get; set; } //Категория лучших товаров

        public bool Available { get; set; } //Остаток товара на складе

        public int CategoryID { get; set; } //Категория товара

        public Category Category { get; set; } //Объект категории

    }
}
