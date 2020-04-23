using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtGallery.BLL.Contracts;
using ArtGallery.BLL.Implementation;
using ArtGallery.DataAccess.Context;
using ArtGallery.DataAccess.Contracts;
using ArtGallery.DataAccess.Implementations;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace ArtGallery.WebApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            // BLL
            services.Add(new ServiceDescriptor(typeof(ISketchCreateService), typeof(SketchCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ISketchGetService), typeof(SketchGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ISketchUpdateService), typeof(SketchUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICategoryGetService), typeof(CategoryGetService), ServiceLifetime.Scoped));

            // DataAccess
            services.Add(new ServiceDescriptor(typeof(ISketchDataAccess), typeof(SketchDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ICategoryDataAccess), typeof(CategoryDataAccess), ServiceLifetime.Transient));

            // DB Contexts
            services.AddDbContext<SketchDirectoryContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("SketchDirectory")));
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

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
