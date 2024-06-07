using Application.Interface.Repositories;
using Application.Interface.UnitOfWork;
using Domain.Entities;
using Infrastructure.Data_Access;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly ProjectDbContext _dbContext;

        public ITemplateRepository ITemplateRepository { get; private set; }
        

        
        

        public UnitOfWorkRepository(ProjectDbContext dbContext, ITemplateRepository templateRepository) {

            _dbContext = dbContext;
            ITemplateRepository= templateRepository;
            
        }

        //Get Region Id by Address.CityId 
        //public Task<string> GetCountryByRegionId(string regionId)
        //{
        //    string countryId = _dbContext.City.Where(x => x.REGION_ID == regionId).FirstOrDefault().COUNTRY_ID;
        //    return Task.FromResult(countryId);
        //}


        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
