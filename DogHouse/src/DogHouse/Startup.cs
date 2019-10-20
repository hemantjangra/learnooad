using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBOps.DBContext;
using DBOps.Repository;
using DBOps.UOW;
using DogHouse.DBRepository;
using DogHouse.DoorHelper;
using DogHouse.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DogHouse
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IDogDoorOperations, DogDoorOperations>();
            services.AddScoped<IRemoteOperations, RemoteOperations>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMongoContext>(sp => 
                                new MongoContext(Configuration.GetValue<string>("mongoSettings:connectionString"), 
                                                 Configuration.GetValue<string>("mongoSettings:databaseName")));
            services.AddScoped<IDoorRepository, DoorRepository>();
            services.Configure<AppSettings>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
