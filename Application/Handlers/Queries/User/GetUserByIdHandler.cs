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
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, UserDto>
    {
        private readonly IMapper _mapper;

        private readonly IUserRepository _repository;

        public GetUserByIdHandler(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UserDto> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _repository.GetUserById(request.Id);
                UserDto result = _mapper.Map<UserDto>(user);
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
