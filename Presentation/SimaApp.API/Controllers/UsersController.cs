using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimaApp.Application.Features.Companies.Command.CreateProduct;
using SimaApp.Application.Features.Roles.Command.DeleteRole;
using SimaApp.Application.Features.Users.Command.AssignRole;
using SimaApp.Application.Features.Users.Command.CreateUser;
using SimaApp.Application.Features.Users.Command.CreateUserProfile;
using SimaApp.Application.Features.Users.Command.DeleteRole;
using SimaApp.Application.Features.Users.Command.DeleteUSer;
using SimaApp.Application.Features.Users.Command.DeleteUserProfile;
using SimaApp.Application.Features.Users.Command.UpdateUser;
using SimaApp.Application.Features.Users.Queries.GetAllUser;
using SimaApp.Application.Features.Users.Queries.GetUser;
using SimaApp.Application.Features.Users.Queries.GetUserProfile;
using SimaApp.Application.Features.Users.Queries.GetUserProfileRolesByPIN;

namespace SimaApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetUser([FromQuery]GetUserQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var response = await _mediator.Send(new GetAllUserQueryRequest());
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUserProfileRolesByPin([FromQuery]GetUserProfileRolesByPINQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProfile([FromQuery] GetUserProfileQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserProfile(CreateUserProfileCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUserProfile(DeleteUserProfileCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(AssignRoleCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUserRole(DeleteUserRoleCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
