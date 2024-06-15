using Domain.Entities;
using Infrastructure.Data_Access;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class UserRepository: GenericRepository<User>, IUserRepository
{
    private readonly ProjectDbContext _dbContext;

    public UserRepository(ProjectDbContext dbContext):base(dbContext) 
    { 
        _dbContext = dbContext;
    }   
}

