using Application.Interface.Repositories;
using Application.Requests.Commands;
using Application.Validators;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Commands
{
    public class UpdateTemplateCommandHandler : IRequestHandler<UpdateTemplateRequestCommand, BaseCommandResponse>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateTemplateCommandHandler> _logger;

        public UpdateTemplateCommandHandler(ILogger<UpdateTemplateCommandHandler> logger, ITemplateRepository templateRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<BaseCommandResponse> Handle(UpdateTemplateRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var response = new BaseCommandResponse();
                var validator = new TemplateDtoValidator(_templateRepository);
                var TemplateUpdateRequest = _mapper.Map<Domain.Entities.Template>(request.UpdateTemplateDto);
                var validationResult = await validator.ValidateAsync(request.UpdateTemplateDto);

                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                }
                else
                {
                    var Template = await _templateRepository.Get(request.UpdateTemplateDto.templateId);
                    //var updateCreationRequest = _mapper.Map<Template>(request.UpdateTemplateDto);
                    //TemplateCreationRequest = await _TemplateRepository.Add(TemplateCreationRequest);
                    _mapper.Map(request.UpdateTemplateDto, Template);

                    await _templateRepository.Update(Template);

                    response.Success = true;
                    response.Message = "Update Successful";
                    response.Id2 = TemplateUpdateRequest.templateId;

                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Create Project Event: {DomainEvent}", ex.Message);
                throw;

            }

        }
    }
}
