using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimaApp.Application.Features.EmployeeCompanies.Command.ChangePosition;
using SimaApp.Application.Features.EmployeeCompanies.Command.CreateEmployeeCompany;
using SimaApp.Application.Features.EmployeeCompanies.Command.CreateSignInAuthority;
using SimaApp.Application.Features.EmployeeCompanies.Command.DeleteEmployeeCompany;
using SimaApp.Application.Features.EmployeeCompanies.Command.DeleteSignIntAuthority;
using SimaApp.Application.Features.EmployeeCompanies.Command.UpdateEmployee;
using SimaApp.Application.Features.EmployeeCompanies.Queries.GetAllEmployeesByCompanyId;
using SimaApp.Application.Features.EmployeeCompanies.Queries.GetEmployee;
using SimaApp.Application.Features.Roles.Queries.GetAllRoles;

namespace SimaApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeCompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeCompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee([FromQuery]GetEmployeeQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesByCompanyId([FromQuery]GetAllEmployeesByCompanyIdQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(CreateEmployeeCompanyCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployeeCompany(DeleteEmployeeCompanyCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> ChangeEmployeePosition(ChangeEmployeePositionCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSignInAuthority(CreateSignInAuthorityCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSignInAuthority(DeleteSignIntAuthorityCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
