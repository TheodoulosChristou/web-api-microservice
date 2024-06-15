using Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.User
{
    public class UpdateUserCommand: IRequest<UserDto>
    {
        public UserDto UpdateUser { get; set; }
    }
}
