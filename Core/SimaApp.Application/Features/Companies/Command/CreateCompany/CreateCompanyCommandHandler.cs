using MediatR;
using SimaApp.Application.Features.Companies.Command.CreateProduct;
using SimaApp.Application.Features.Companies.Rules;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Command.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CompanyRules _companyRules;
        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork, CompanyRules companyRules)
        {
            _unitOfWork = unitOfWork;
            _companyRules = companyRules;
        }

        public async Task<Unit> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var companies = await  _unitOfWork.GetReadRepository<Company>().GetAllAsync();
            await _companyRules.CompanyNameMustBeUnique(companies, request.Name);
            var company = new Company
            {
                Name = request.Name,
                TIN = request.TIN,
            };

            await _unitOfWork.GetWriteRepository<Company>().AddAsync(company);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
