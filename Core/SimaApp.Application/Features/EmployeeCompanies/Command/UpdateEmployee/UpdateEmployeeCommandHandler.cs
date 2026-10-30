using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.GetReadRepository<Employee>().GetAsync(x=>x.Id==request.Id,include:query=>(query.Include(x=>x.EmployeeDocument)));
            if (employee == null)
            {
                throw new NotFoundException("İşçi tapılmadı.");
            }
            employee.Name = request.Name;
            employee.Surname = request.Surname;
            employee.FullName = request.Fullname;
            employee.EmployeeDocument.PIN = request.PIN;
            employee.EmployeeDocument.UpdatedAt = DateTime.Now.AddHours(4);
            employee.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.GetWriteRepository<Employee>().UpdateAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
            throw new NotImplementedException();
        }
    }
}
