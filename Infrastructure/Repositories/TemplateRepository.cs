using Application.DTOs;
using Application.Interface.Repositories;
using Domain.Entities;
using Infrastructure.Repositories.Base;
using Infrastructure.Data_Access;

namespace Infrastructure.Repositories
{
    public class TemplateRepository : GenericRepository<Template>, ITemplateRepository
    {
        private readonly ProjectDbContext _dbContext;

        public TemplateRepository(ProjectDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
