using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.Features.Roles.Queries.GetRole;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Queries.GetEmployee
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQueryRequest, GetEmployeeQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEmployeeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetEmployeeQueryResponse> Handle(GetEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.GetReadRepository<EmployeeDocument>().GetAsync(x => x.PIN == request.Pin && !x.IsDeleted,x=>x.Include(ec=>ec.Employee));

            if (employee is null)
            {
                throw new NotFoundException();
            }

            var response = new GetEmployeeQueryResponse
            {
                Name = employee.Employee.Name,
                Surname = employee.Employee.Surname,
                Fullname = employee.Employee.FullName,
                PIN = request.Pin,
            };
            return response;
        }
    }
}
