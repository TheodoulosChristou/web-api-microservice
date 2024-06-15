using Application.DTOs.User;
using Application.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public interface IUserRepository: IGenericRepository<User>
    {
       Task<List<User>> SearchUsersByCriteria(SearchUserCriteriaDto searchCriteria);

       Task<User> GetUserById(int id);
    }

