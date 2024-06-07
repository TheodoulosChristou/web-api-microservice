using Application.Interface.Repositories;
using Application.Requests.Commands;
using Application.Validators;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Commands
{
    public class DeleteTemplateCommandHandlers : IRequestHandler<DeleteTemplateRequestCommand, BaseCommandResponse>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteTemplateCommandHandlers> _logger;

        public DeleteTemplateCommandHandlers(ITemplateRepository templateRepository, IMapper mapper, ILogger<DeleteTemplateCommandHandlers> logger)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<BaseCommandResponse> Handle(DeleteTemplateRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = new BaseCommandResponse();
                var templateDeleteRequest = _mapper.Map<Domain.Entities.Template>(request.DeleteTemplateDto);

                var Template = await _templateRepository.Get(request.DeleteTemplateDto.templateId);
                _mapper.Map(request.DeleteTemplateDto, Template);
                await _templateRepository.Delete(Template);

                response.Success = true;
                response.Message = "Delete Succesful";
                response.Id2 = templateDeleteRequest.templateId;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Delete Template  Event: {DomainEvent}", ex.Message);
                throw;
            }



        }
    }
}

