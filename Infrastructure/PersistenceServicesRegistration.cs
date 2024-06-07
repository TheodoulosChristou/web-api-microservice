using Application.Interface.Repositories;
using Application.Interface;
using AutoMapper.Configuration;
using Domain;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Infrastructure.Data_Access;
using Application.Interface.UnitOfWork;
using Infrastructure.Repositories.UnitOfWork;

namespace Infrastructure
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("ProjectDatabase")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();

            

            return services;
        }
    }
}
