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

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IMapper _mapper;

        private readonly IUserRepository _repository;

        public UpdateUserHandler(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new UserDtoValidator(_repository);
                var valRes = await validator.ValidateAsync(request.UpdateUser);

                if(valRes.IsValid == false)
                {
                    throw new Exception("Validation Failed. Some fields are required");
                } else
                {
                    var userRequest = _mapper.Map<User>(request.UpdateUser);
                    await _repository.Update(userRequest);
                    UserDto result = _mapper.Map<UserDto>(userRequest);
                    return result;
                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }

