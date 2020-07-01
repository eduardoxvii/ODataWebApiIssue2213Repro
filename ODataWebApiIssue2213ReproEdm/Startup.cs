using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ODataWebApiIssue2213ReproEdm.Data;
using ODataWebApiIssue2213ReproEdm.Models;
using System.Linq;

namespace ODataWebApiIssue2213ReproEdm
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(this.Configuration);
            services.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase(databaseName: "Edm2213Db"));
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddOData();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<School>("School");

            // Edm Approach
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Filter().Expand().Select().OrderBy().MaxTop(null).SkipToken();
                routeBuilder.MapODataServiceRoute("odata", string.Empty, modelBuilder.GetEdmModel());
            });

            using (IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                InMemoryDbContext db = serviceScope.ServiceProvider.GetRequiredService<InMemoryDbContext>();

                if (!db.Schools.Any())
                {
                    var shippingAddress = new StreetAddress { Id = 1, Street = "Street 1", City = "City 1" };
                    db.StreetAddresses.Add(shippingAddress);

                    var order = new Order { Id = 1, Description = "Order 1 Description " };
                    db.Orders.Add(order);

                    db.Schools.Add(new School { Id = 1, Name = "School 1", ShippingAddress = shippingAddress, Order = order });

                    db.SaveChanges();
                }
            }
        }
    }
}
