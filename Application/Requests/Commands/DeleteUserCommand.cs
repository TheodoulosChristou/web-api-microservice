﻿using Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands
{
    public class DeleteUserCommand: IRequest<BaseCommandResponse>
    {
        public UserDto DeleteUser { get; set; }
    }
}
