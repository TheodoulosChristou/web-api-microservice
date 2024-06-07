using MediatR;
using Application.DTOs;

namespace Application.Requests.Commands
{
    public class CreateTemplateRequestCommand : IRequest<BaseCommandResponse>
    {
        public TemplateDto CreateTemplateDto {get; set;}
    }
}
