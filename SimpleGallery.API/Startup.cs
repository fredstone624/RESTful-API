using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleGallery.API.Domain.Models;
using SimpleGallery.API.Domain.Repositories;
using SimpleGallery.API.Domain.Services;
using SimpleGallery.API.Persistence.Contexts;
using SimpleGallery.API.Persistence.Repositories;
using SimpleGallery.API.Services;

namespace SimpleGallery.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddScoped<IRepository<Album, string>, AlbumRepository>();
            services.AddScoped<IService<Album, string>, AlbumService>();

            services.AddScoped<IRepository<Photo, string>, PhotoRepository>();
            services.AddScoped<IService<Photo, string>, PhotoService>();

            services.AddScoped<IRepository<Image, string>, ImageRepository>();
            services.AddScoped<IService<Image, string>, ImageService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}