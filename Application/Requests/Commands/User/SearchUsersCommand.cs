using Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.User
{
    public class SearchUsersCommand: IRequest<List<UserDto>>
    {
        public SearchUserCriteriaDto searchCriteria { get; set; }
    }
}
