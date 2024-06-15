using Application.DTOs.User;
using Application.Interface.Validators.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.User
{
    public class UserDtoValidator: AbstractValidator<UserDto>
    {
        private readonly IUserRepository _repository;

        public UserDtoValidator(IUserRepository repository)
        {
            _repository = repository;
            Include(new IUserDtoValidator(_repository));
        }
    }
}
