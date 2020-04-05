using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalTaskAsp.Abstract;
using FinalTaskAsp.Entities;
using FinalTaskAsp.Models;
using FinalTaskAsp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace FinalTaskAsp
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
            //services.AddDbContext<MyDbContext>(opt => opt.UseInMemoryDatabase("test_dump"));
            //services.AddControllers();

            services.AddControllers();
            services.AddControllers(options => options.MaxIAsyncEnumerableBufferLimit = 15000);
            services.AddDbContext<TestDbContext>(ServiceLifetime.Scoped);
            services.AddScoped(typeof(ICountryService), typeof(CountryService));
            services.AddScoped(typeof(IPersonService), typeof(PersonService));
            services.AddScoped(typeof(IPersonContactService), typeof(PersonContactService));
            services.AddScoped(typeof(IGreetingService), typeof(GreetingService));

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
