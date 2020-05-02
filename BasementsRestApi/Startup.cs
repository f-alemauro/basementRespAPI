using BasementsRestApi.Models;
using BasementsRestApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasementsRestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //using (var ctx = new BasementContext())
            //{
            //    ctx.Database.EnsureCreated();
            //}
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(
                    o =>
                    {
                        o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    }
                );

            services.AddScoped<IItemRepository, ItemRepository>();
            //services.AddEntityFrameworkSqlite().AddDbContext<BasementContext>();
            var db = services.AddDbContext<BasementContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            
            //services.AddDbContext<ItemContext>(options => options.UseInMemoryDatabase(databaseName: "BasementApiDB"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Items}/{action=Index}");
            });
        }
    }
}