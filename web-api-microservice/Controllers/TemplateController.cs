//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.DTOs;
using Application.Requests.Queries;

using Application.Handlers.Commands;
using Application.Requests.Commands;

namespace Location.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TemplateController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet("details")]
        public async Task<ActionResult<IQueryable<TemplateDto>>> GetQueryResults()
        {
            var leaveAllocations = await _mediator.Send(new GetTemplateIQuerableRequest());
            return Ok(leaveAllocations);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TemplateDto createTemplateRequest)
        {
            var command = new CreateTemplateRequestCommand { CreateTemplateDto= createTemplateRequest };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] TemplateDto updateTemplateRequest) 
        {
            var command = new UpdateTemplateRequestCommand { UpdateTemplateDto= updateTemplateRequest };
            var response = await _mediator.Send(command);
            return Ok(response);

        }
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] TemplateDto deleteTemplateRequest) 
        {
            var command = new DeleteTemplateRequestCommand { DeleteTemplateDto= deleteTemplateRequest };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
