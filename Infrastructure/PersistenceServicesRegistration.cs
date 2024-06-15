using Application.Interface;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Infrastructure.Data_Access;
using Application.Interface.UnitOfWork;
using Infrastructure.Repositories.UnitOfWork;

namespace Application
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("ProjectDatabase")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            

            return services;
        }
    }
}
