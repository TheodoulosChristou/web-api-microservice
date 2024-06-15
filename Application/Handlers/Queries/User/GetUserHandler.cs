using Application.DTOs.User;
using Application.Requests.Queries.User;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Queries.User
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, List<UserDto>>
    {
        private readonly IMapper _mapper;

        private readonly IUserRepository _repository;

        public GetUserHandler(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<UserDto>> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userList = await _repository.GetAll();
                List<UserDto> result = _mapper.Map<List<UserDto>>(userList);    
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
