using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimaApp.Application.Features.Companies.Queries.GetAllCompanies;
using SimaApp.Application.Features.Roles.Command.CreateRole;
using SimaApp.Application.Features.Roles.Command.DeleteRole;
using SimaApp.Application.Features.Roles.Command.UpdateRole;
using SimaApp.Application.Features.Roles.Queries.GetAllRoles;
using SimaApp.Application.Features.Roles.Queries.GetRole;

namespace SimaApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult>GetRole([FromQuery]GetRoleQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var response = await _mediator.Send(new GetAllRolesQueryRequest());
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRole(DeleteRoleCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
