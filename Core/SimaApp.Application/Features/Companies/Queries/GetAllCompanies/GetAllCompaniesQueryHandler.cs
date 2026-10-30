using MediatR;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Queries.GetAllCompanies
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQueryRequest, IList<GetAllCompaniesQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCompaniesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllCompaniesQueryResponse>> Handle(GetAllCompaniesQueryRequest request, CancellationToken cancellationToken)
        {
            var companies = await _unitOfWork.GetReadRepository<Company>().GetAllAsync();

            List<GetAllCompaniesQueryResponse> response = new();

            foreach(var company in companies)
            {
                response.Add(new GetAllCompaniesQueryResponse
                {
                    Name = company.Name,
                    TIN = company.TIN
                });
            }
            return response;
        }
    }
}
