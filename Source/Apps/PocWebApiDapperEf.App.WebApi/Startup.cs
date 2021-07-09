using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PocWebApiDapperEf.Core.Application.Interfaces;
using PocWebApiDapperEf.Core.Application.Services;
using PocWebApiDapperEf.Infra.PersistenceDapper.Repositories;
using PocWebApiDapperEf.Infra.PersistenceEf.Contexts;
using PocWebApiDapperEf.Infra.PersistenceEf.Repositories;

namespace PocWebApiDapperEf.App.WebApi
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
            // Db Context
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
               Configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Repositories
            services.AddScoped<ICurvaUsingEfRepository, CurvaUsingEfRepository>();
            services.AddScoped<ICurvaUsingDapperRespository, CurvaUsingDapperRepository>();
            services.AddScoped<ICurvaUsingEfService, CurvaUsingEfService>();
            services.AddScoped<ICurvaUsingDapperService, CurvaUsingDapperService>();

            // Swagger
            services.AddSwaggerGen();
            
            // Add Controllers
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "POC API Curvas");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
