using MediatR;
using Microsoft.EntityFrameworkCore;
using SimaApp.Application.Features.Roles.Queries.GetAllRoles;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SimaApp.Application.Features.EmployeeCompanies.Queries.GetAllEmployeesByCompanyId
{
    public class GetAllEmployeesByCompanyIdQueryHandler : IRequestHandler<GetAllEmployeesByCompanyIdQueryRequest, IList<GetAllEmployeesByCompanyIdQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllEmployeesByCompanyIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllEmployeesByCompanyIdQueryResponse>> Handle(GetAllEmployeesByCompanyIdQueryRequest request, CancellationToken cancellationToken)
        {
            //var employeesCompanies = await _unitOfWork.GetReadRepository<EmployeesCompanies>().GetAllAsync(x => x.CompanyId == request.CompanyId);
            var employees = await _unitOfWork.GetReadRepository<Employee>().GetAllAsync(x => x.EmployeesCompanies.Any(x => x.CompanyId == request.CompanyId), include: query => query.Include(x => x.EmployeeDocument).Include(x=>x.EmployeesCompanies));
          
            List < GetAllEmployeesByCompanyIdQueryResponse > response = new();

            foreach (var employee in employees)
            {
                response.Add(new GetAllEmployeesByCompanyIdQueryResponse
                {
                    Id = employee.Id,
                    Fullname = employee.FullName,
                    PIN=employee.EmployeeDocument.PIN,
                    Position=employee.EmployeesCompanies.FirstOrDefault(x=>x.EmployeeId==employee.Id && x.CompanyId == request.CompanyId).Position
                });
            }
            return response;
        }
    }
}
