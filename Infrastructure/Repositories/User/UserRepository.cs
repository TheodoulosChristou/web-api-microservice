using Application.DTOs.User;
using Domain.Entities;
using Infrastructure.Data_Access;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



public class UserRepository: GenericRepository<User>, IUserRepository
{
    private readonly ProjectDbContext _dbContext;

    public UserRepository(ProjectDbContext dbContext):base(dbContext) 
    { 
        _dbContext = dbContext;
    }

    public async Task<User> GetUserById(int id)
    {
        try
        {
            User result = _dbContext.User.FirstOrDefault(x => x.ID == id);

            if(result  == null)
            {
                throw new Exception("User not found in Db");
            } else
            {
                return result;
            }
        }catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<List<User>> SearchUsersByCriteria(SearchUserCriteriaDto searchCriteria)
    {
        try
        {
            var result = _dbContext.User.ToList();

            result = result = result.Where(x =>
                                (searchCriteria.FIRSTNAME == null || x.FIRSTNAME.Contains(searchCriteria.FIRSTNAME)) &&
                                (searchCriteria.LASTNAME == null || x.LASTNAME.Contains(searchCriteria.LASTNAME)) &&
                                (searchCriteria.DOB == null || x.DOB == searchCriteria.DOB)
                            ).ToList();

            return result;
        }catch (Exception ex)
        {
            throw ex;
        }
    }
}

