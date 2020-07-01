using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ODataWebApiIssue2213ReproNonEdm.Data;
using ODataWebApiIssue2213ReproNonEdm.Models;
using System;
using System.Linq;

namespace ODataWebApiIssue2213ReproNonEdm
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
            services.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase(databaseName: "NonEdm2213Db"));
            services.AddControllers().AddNewtonsoftJson();
            services.AddOData();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            // Non-Edm Approach
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.Select().Filter().Expand().Count().MaxTop(10);
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

                if (!db.Users.Any())
                {
                    db.Users.AddRange(
                        new User { Id = 1, Name = "John Doe", CreatedOn = new DateTimeOffset(DateTime.Parse("2020-06-24T15:57:44.3780001+03:00")) },
                        new User { Id = 2, Name = "Foo Bar", CreatedOn = new DateTimeOffset(DateTime.Now) });

                    db.SaveChanges();
                }
            }
        }
    }
}
