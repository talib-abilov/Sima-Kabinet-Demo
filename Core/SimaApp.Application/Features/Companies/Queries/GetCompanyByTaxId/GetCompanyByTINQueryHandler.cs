using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Queries.GetCompanyByTaxId
{
    public class GetCompanyByTINQueryHandler : IRequestHandler<GetCompanyByTINQueryRequest, GetCompanyByTINQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCompanyByTINQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCompanyByTINQueryResponse> Handle(GetCompanyByTINQueryRequest request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.GetReadRepository<Company>().GetAsync(x => x.TIN == request.TaxId);

            if (company == null)
            {
                throw new NotFoundException("Şirkət tapılmadı");
            }

            GetCompanyByTINQueryResponse response = new GetCompanyByTINQueryResponse()
            {
                Id = company.Id,
                Name = company.Name,
                TaxId = company.TIN
            };

            return response;
        }
    }
}
