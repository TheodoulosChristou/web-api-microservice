using Application;
using Application.Interface.Repositories;
//using Application.Interfaces.Repositories;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using System.Text.Json;

namespace webApiMicroservice
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
            services.AddControllers()
                .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = new UpperCaseNamingPolicy();
            });

            services.AddCors();
            services.ConfigureAppServices();
            services.ConfigureIdentityServices(Configuration);
            services.ConfigurePersistenceServices(Configuration);



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TemplateMicroservice", Version = "V1" });
            });
            services.AddAutoMapper(typeof(Startup));
        }
        private class UpperCaseNamingPolicy : JsonNamingPolicy
        {
            public override string ConvertName(string name)
            {
                return name.ToUpper();
            }
        }

        //public void ConfigureDependancyInjenciton(IServiceCollection services)
        //{
        //    services.AddTransient<ICountryRepository, CountryRepository>();
        //    services.AddTransient<IRegionRepository, RegionRepository>();
        //    services.AddTransient<ICityRepository, CityRepository>();
        //}



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCustomExceptionMiddleware();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}