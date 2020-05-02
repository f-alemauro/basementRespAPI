using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BasementsRestApi.Models
{
    public class BasementContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemDefinition> ItemDefinitions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(@"Filename=DB\Basement.db", options =>
            //{
            //    options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            //});
            base.OnConfiguring(optionsBuilder);
        }

        public BasementContext(DbContextOptions options)
       : base(options)
        {
        //    Database.EnsureCreated();
        }

    }
}