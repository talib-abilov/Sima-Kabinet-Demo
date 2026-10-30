using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Queries.IsCompanyExists
{
    public class IsCompanyExistsQueryHandler : IRequestHandler<IsCompanyExsistsQueryRequest, IsCompanyExistsQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public IsCompanyExistsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IsCompanyExistsQueryResponse> Handle(IsCompanyExsistsQueryRequest request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.GetReadRepository<Company>().GetAsync(x=>x.TIN==request.TIN);
            if (company == null)
            {
                throw new NotFoundException("Şirkət tapılmadı.");
            }
          
            IsCompanyExistsQueryResponse response = new IsCompanyExistsQueryResponse()
            {
                IsCompanyExists = true
            };
            return response;
        }
    }
}
