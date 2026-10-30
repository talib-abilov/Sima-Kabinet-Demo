using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Queries.GetCompany
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQueryRequest,GetCompanyQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCompanyQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCompanyQueryResponse> Handle(GetCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.GetReadRepository<Company>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            if(company is null)
            {
                throw new NotFoundException("Company not found.");
            }

            var response = new GetCompanyQueryResponse
            {
                Name = company.Name,
                TIN = company.TIN
            };

            return response;
        }
    }
}
