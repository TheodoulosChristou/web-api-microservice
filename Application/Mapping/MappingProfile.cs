using Application.DTOs.User;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<UserDto, User>().ReverseMap();
            #endregion

        }
    }
}
