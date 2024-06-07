using Application.DTOs;
using Application.Interface.Repositories;
using Application.Interface.Validators;
using FluentValidation;


namespace Application.Validators
{
    public class TemplateDtoValidator : AbstractValidator<TemplateDto>
    {
        private readonly ITemplateRepository _templateRepository;

        public TemplateDtoValidator(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
            //Include(new IRegionDtoValidator(_regionRepository));
        }

    }
}
