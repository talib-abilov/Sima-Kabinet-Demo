using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.CreateSignInAuthority
{
    public class CreateSignInAuthorityCommandHandler : IRequestHandler<CreateSignInAuthorityCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSignInAuthorityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateSignInAuthorityCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeCompany = await _unitOfWork.GetReadRepository<EmployeesCompanies>().GetAsync(x => x.Id == request.EmployeesCompaniesId && !x.IsDeleted);

            if(employeeCompany is null)
            {
                throw new NotFoundException("Employee company not found");
            }

            var signInAuthority = new SignInAuthority
            {
                EmployeesCompaniesId = employeeCompany.Id
            };

            await _unitOfWork.GetWriteRepository<SignInAuthority>().AddAsync(signInAuthority);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
