using Application.Interface.DTOs;
using Application.Interface.Repositories;
using FluentValidation;


namespace Application.Interface.Validators
{
    public class ITemplateDtoValidator : AbstractValidator<ITemplateDto>
    {
        public ITemplateDtoValidator(ITemplateRepository templateRepository)
        {
            RuleFor(p => p.templateId).NotEmpty().WithMessage("Template must not be empty.");

        }
    }
}
