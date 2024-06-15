using Application;
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


public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, BaseCommandResponse>
{
    private readonly IMapper _mapper;

    private readonly IUserRepository _repository;

    public DeleteUserHandler(IMapper mapper, IUserRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<BaseCommandResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            BaseCommandResponse response = new BaseCommandResponse();
            var validator = new UserDtoValidator(_repository);
            var valRes = await validator.ValidateAsync(request.DeleteUser);

            if(valRes.IsValid == false)
            {
                throw new Exception("Validation Failed. Some Fields are required");
            } else
            {
                var userRequest = _mapper.Map<User>(request.DeleteUser);
                await _repository.Delete(userRequest);
                response.Success = true;
                response.Message = "User has been deleted successfully";
                response.Id = userRequest.ID;

                return response;
            }
        }catch (Exception ex)
        {
            throw ex;
        }
    }
}

