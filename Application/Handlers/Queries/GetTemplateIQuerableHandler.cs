using Application.DTOs;
using Application.Interface.Repositories;
using Application.Requests.Queries;
using AutoMapper;
using MediatR;


namespace Application.Handlers.Queries
{
    public class GetTemplateIQuerableHandler : IRequestHandler<GetTemplateIQuerableRequest, List<TemplateDto>>
    {
        private readonly ITemplateRepository _TemplateRepository;
        private readonly IMapper _mapper;

        public GetTemplateIQuerableHandler(ITemplateRepository ProjectRepository, IMapper mapper)
        {
            _TemplateRepository = ProjectRepository;
            _mapper = mapper;
        }
        public async Task<List<TemplateDto>> Handle(GetTemplateIQuerableRequest request, CancellationToken cancellationToken)
        {


            var Project = await _TemplateRepository.GetAll();
            return _mapper.Map<List<TemplateDto>>(Project);


        }
    }

}
