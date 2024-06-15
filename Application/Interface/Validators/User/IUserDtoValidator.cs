using Application.DTOs.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Validators.User
{
    public class IUserDtoValidator: AbstractValidator<UserDto>
    {
        private readonly IUserRepository _repository;

        public IUserDtoValidator(IUserRepository repository)
        {
            _repository = repository;
            RuleFor(x => x.FIRSTNAME).NotEmpty().WithMessage("FIRSTNAME must not be null");

            RuleFor(x => x.LASTNAME).NotEmpty().WithMessage("LASTNAME must not be null");

            RuleFor(x => x.DOB).NotEmpty().WithMessage("DOB must not be null");
        }
    }
}
