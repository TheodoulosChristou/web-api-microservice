using Application.Interface.Repositories;
using Application.Requests.Commands;
using Application.Validators;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Domain.Entities;
using Application.Interface.UnitOfWork;

namespace Application.Handlers.Commands
{
    public class CreateTemplateCommandHandlers : IRequestHandler<CreateTemplateRequestCommand, BaseCommandResponse>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTemplateCommandHandlers> _logger;

        public CreateTemplateCommandHandlers(ILogger<CreateTemplateCommandHandlers> logger, ITemplateRepository templateRepository, IMapper mapper,IUnitOfWork unitOfWork)
        {
            _templateRepository = templateRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<BaseCommandResponse> Handle(CreateTemplateRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var response = new BaseCommandResponse();
                var validator = new TemplateDtoValidator(_templateRepository);
                var validationResult = await validator.ValidateAsync(request.CreateTemplateDto);



                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                }
                else
                {

                    var templateCreationRequest = _mapper.Map<Template>(request.CreateTemplateDto);
                    templateCreationRequest = await _templateRepository.Add(templateCreationRequest);

                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Id2 = templateCreationRequest.templateId;

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
