using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.DeleteEmployeeCompany
{
    public class DeleteEmployeeCompanyCommandHandler : IRequestHandler<DeleteEmployeeCompanyCommandRequest, Unit>

    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteEmployeeCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var empComp = await _unitOfWork.GetReadRepository<EmployeesCompanies>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            if(empComp is null)
            {
                throw new NotFoundException();
            }
            empComp.IsDeleted = true;
            await _unitOfWork.GetWriteRepository<EmployeesCompanies>().UpdateAsync(empComp);
            await _unitOfWork.SaveChangesAsync();
            return  Unit.Value;
        }
    }
}
