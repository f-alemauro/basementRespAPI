using System;
using System.Collections.Generic;
using BasementsRestApi.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BasementsRestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            //this is necessary to populate the in memory database;
            //once deployed with a real db, please comment this
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ItemContext>();
                var fakeItems = GenerateFakeData();
                context.Items.AddRange(fakeItems);
                context.SaveChanges();
            }

            host.Run();
        }

        private static List<Item> GenerateFakeData()
        {
            User u = new User
            {
                Name = "Alessio",
                LastActivityTimestamp = DateTime.Now
            };

            ItemDefinition iDef = new ItemDefinition
            {
                Description = "Full Milk",
                Volume = 1,
                Type = Commons.ItemType.BEVERAGE,
                UnitOfMeasurement = Commons.UnitOfMeasurements.LITER
            };

            Item i = new Item
            {
                ItemDefinition = iDef,
                User = u,
                AddedOn = new DateTime(2019, 07, 23),
                ExpireOn = new DateTime(2019, 07, 26),
                Quantity = 1

            };

            ItemDefinition iDef_1 = new ItemDefinition
            {
                Description = "Still water",
                Volume = 2,
                Type = Commons.ItemType.BEVERAGE,
                UnitOfMeasurement = Commons.UnitOfMeasurements.LITER
            };

            Item i_1 = new Item
            {
                ItemDefinition = iDef_1,
                User = u,
                AddedOn = new DateTime(2019, 07, 24),
                ExpireOn = new DateTime(2020, 07, 26),
                Quantity = 3
            };
            var items = new List<Item>
            {
                i,
                i_1
            };
            return items;
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
            .UseStartup<Startup>();
    }
}
