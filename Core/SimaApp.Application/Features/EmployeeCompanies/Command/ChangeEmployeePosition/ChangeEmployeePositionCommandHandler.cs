using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.Features.EmployeeCompanies.Command.ChangePosition;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.ChangeEmployeePosition
{
    public class ChangeEmployeePositionCommandHandler : IRequestHandler<ChangeEmployeePositionCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeEmployeePositionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(ChangeEmployeePositionCommandRequest request, CancellationToken cancellationToken)
        {
            var empComp = await _unitOfWork.GetReadRepository<EmployeesCompanies>().GetAsync(x=>x.Id == request.Id && !x.IsDeleted);
            if(empComp is null)
            {
                throw new NotFoundException();
            }
            empComp.Position = request.Position;
            empComp.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _unitOfWork.GetWriteRepository<EmployeesCompanies>().UpdateAsync(empComp);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
