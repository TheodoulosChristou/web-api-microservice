﻿using Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.User
{
    public class GetUserRequest: IRequest<List<UserDto>>
    {

    }
}
