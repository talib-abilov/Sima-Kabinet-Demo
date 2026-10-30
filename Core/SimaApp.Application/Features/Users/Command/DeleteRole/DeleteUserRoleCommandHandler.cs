using MediatR;
using MediatR.Pipeline;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.DeleteRole
{
    public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommandRequest, Unit>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteUserRoleCommandRequest request, CancellationToken cancellationToken)
        {


            var userProfilerole = await _unitOfWork.GetReadRepository<UserProfilesRoles>().GetAsync(x => x.Id == request.Id);
            if(userProfilerole is null)
            {
                throw new NotFoundException("USer profile role not found.");

            }

            userProfilerole.IsDeleted = true;
            await _unitOfWork.GetWriteRepository<UserProfilesRoles>().UpdateAsync(userProfilerole);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
