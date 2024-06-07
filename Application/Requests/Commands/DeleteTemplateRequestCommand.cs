using Application.DTOs;
using MediatR;


namespace Application.Requests.Commands
{
    public class DeleteTemplateRequestCommand : IRequest<BaseCommandResponse>
    {
        public TemplateDto DeleteTemplateDto { get; set; }
    }
}
