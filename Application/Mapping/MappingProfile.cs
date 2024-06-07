using AutoMapper;
using Application.DTOs;


namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region
            CreateMap<Domain.Entities.Template, TemplateDto>().ReverseMap();
            #endregion
        }
    }
}
