using MediatR;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.CreateEmployeeCompany
{
    public class CreateEmployeeCompanyCommandHandler : IRequestHandler<CreateEmployeeCompanyCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEmployeeCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateEmployeeCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var empDocument = new EmployeeDocument
            {
                PIN = request.PIN,
            };
            var employee = new Employee
            {
                Name = request.Name,
                Surname = request.Surname,
                FullName = request.Fullname,
                EmployeeDocument = empDocument,
            };
            await _unitOfWork.GetWriteRepository<Employee>().AddAsync(employee);

            var empCompany = new EmployeesCompanies
            {
                CompanyId = request.CompanyId,
                Position = request.Position,
                Employee = employee
            };
            await _unitOfWork.GetWriteRepository<EmployeesCompanies>().AddAsync(empCompany);
    
            await _unitOfWork.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}
