using Application.DTOs.User;
using Application.Requests.Commands.User;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Commands.User
{
    public class SearchUserByCriteriaHandler : IRequestHandler<SearchUsersCommand, List<UserDto>>
    {
        private readonly IMapper _mapper;

        private readonly IUserRepository _repository;

        public SearchUserByCriteriaHandler(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<UserDto>> Handle(SearchUsersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _repository.SearchUsersByCriteria(request.searchCriteria);
                List<UserDto> result = _mapper.Map<List<UserDto>>(users);   
                return result;
            }catch  (Exception ex)
            {
                throw ex;
            }
        }
    }
}
