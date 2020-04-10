using Microsoft.EntityFrameworkCore;

namespace BasementsRestApi.Models
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemDefinition> ItemDefinitions { get; set; }
        public DbSet<User> Users { get; set; }


        public ItemContext(DbContextOptions options)
       : base(options)
        {
        }

    }
}