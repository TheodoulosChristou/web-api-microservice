using Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.User
{
    public class CreateUserCommand: IRequest<UserDto>
    {
        public UserDto CreateUser {  get; set; }
    }
}
