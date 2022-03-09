using LernASP.data.Internal_models;
using Microsoft.EntityFrameworkCore;

namespace LernASP.data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) //
        {
            
        }
        public DbSet<Detail> Details { get; set; } = null!; //Устанавливает все товары
        public DbSet<Category> Categories { get; set; } = null!; //Устанавливает все категории
        public DbSet<ShopCartItem> ShopCartItems { get; set; } = null!;
    }
}
