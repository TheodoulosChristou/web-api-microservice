using Application;
using Application.DTOs.User;
using Application.Requests.Commands;
using Application.Requests.Commands.User;
using Application.Requests.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAllUsers")]
    public async Task<ActionResult<IQueryable<UserDto>>> GetAllUsers()
    {
        var request = new GetUserRequest {  };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("GetUserById")]
    public async Task<ActionResult<IQueryable<UserDto>>> GetUserById(int id)
    {
        var request = new GetUserByIdRequest { Id = id};
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("CreateUser")]
    public async Task<ActionResult<IQueryable<UserDto>>> CreateUser([FromBody] UserDto CreateUser)
    {
        var request = new CreateUserCommand { CreateUser = CreateUser };
        var response = await _mediator.Send(request);
        return Ok(response);
    }


    [HttpPost("SearchUserByCriteria")]
    public async Task<ActionResult<IQueryable<UserDto>>> SearchUserByCriteria([FromBody] SearchUserCriteriaDto? searchCriteria)
    {
        var request = new SearchUsersCommand { searchCriteria = searchCriteria };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("UpdateUser")]
    public async Task<ActionResult<IQueryable<UserDto>>> UpdateUser([FromBody] UserDto UpdateUser)
    {
        var request = new UpdateUserCommand { UpdateUser = UpdateUser };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("DeleteUser")]
    public async Task<ActionResult<BaseCommandResponse>> DeleteUser([FromBody] UserDto DeleteUser)
    {
        var request = new DeleteUserCommand { DeleteUser = DeleteUser };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}

