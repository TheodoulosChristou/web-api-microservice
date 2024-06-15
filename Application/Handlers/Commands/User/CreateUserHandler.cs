using Application.DTOs.User;
using Application.Requests.Commands.User;
using Application.Validators.User;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IMapper _mapper;

        private readonly IUserRepository _repository;

        public CreateUserHandler(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new UserDtoValidator(_repository);
                var validationResult = await validator.ValidateAsync(request.CreateUser);

                if(validationResult.IsValid == false)
                {
                    throw new Exception("Validation failed. Some fields are mandatory");
                } else
                {
                    var userRequest =_mapper.Map<User>(request.CreateUser);
                    var userResponse = await _repository.Add(userRequest);
                    UserDto result = _mapper.Map<UserDto>(userResponse);
                    return result;
                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }

