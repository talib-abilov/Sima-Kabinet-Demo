using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.Features.EmployeeCompanies.Command.DeleteSignIntAuthority;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.DeleteSignInAuthority
{
    public class DeleteSignInAuthorityCommandHandler : IRequestHandler<DeleteSignIntAuthorityCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSignInAuthorityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteSignIntAuthorityCommandRequest request, CancellationToken cancellationToken)
        {
            var signInAuthority = await _unitOfWork.GetReadRepository<SignInAuthority>().GetAsync(x=>x.Id==request.Id);
            if(signInAuthority is null)
            {
                throw new NotFoundException("SignIn Authority not found.");
            }
            signInAuthority.IsDeleted = true;
            await _unitOfWork.GetWriteRepository<SignInAuthority>().UpdateAsync(signInAuthority);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
