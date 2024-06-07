using Application.DTOs;
using MediatR;


namespace Application.Requests.Commands
{
    public class UpdateTemplateRequestCommand : IRequest<BaseCommandResponse>
    {
        public TemplateDto UpdateTemplateDto { get; set; }
    }
}
