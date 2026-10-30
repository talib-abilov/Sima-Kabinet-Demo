using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimaApp.Application.Features.Companies.Command.CreateProduct;
using SimaApp.Application.Features.Companies.Command.DeleteCompany;
using SimaApp.Application.Features.Companies.Command.UpdateCompany;
using SimaApp.Application.Features.Companies.Queries.GetAllCompanies;
using SimaApp.Application.Features.Companies.Queries.GetCompany;
using SimaApp.Application.Features.Companies.Queries.GetCompanyByTaxId;
using SimaApp.Application.Features.Companies.Queries.IsCompanyExists;

namespace SimaApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetCompanyQueryRequest(id));
            return Ok(response);
        }
        [HttpGet("{TIN}")]
        public async Task<IActionResult> GetCompanyByTIN([FromRoute] string TIN)
        {
            var response = await _mediator.Send(new GetCompanyByTINQueryRequest() { TaxId=TIN});
            return Ok(response);
        }
        [HttpGet("isCompanyExists")]
        public async Task<IActionResult> IsExistsCompany([FromQuery] string TIN)
        {
            var response = await _mediator.Send(new IsCompanyExsistsQueryRequest() { TIN=TIN});
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var response = await _mediator.Send(new GetAllCompaniesQueryRequest());   
            return Ok(response); 
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(DeleteCompanyCommandRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }
    }
}
