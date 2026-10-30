using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.AssignRole
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommandRequest, Unit>
    {

        private readonly IUnitOfWork _unitOfWork;

        public AssignRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(AssignRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.GetReadRepository<Role>().GetAsync(x => x.Id == request.RoleId && !x.IsDeleted);
            if (role is null)
            {
                throw new NotFoundException("Role not found.");
            }

            var userProfile = await _unitOfWork.GetReadRepository<UserProfile>().GetAsync(x => x.Id == request.UserProfileId && !x.IsDeleted);
            if (userProfile is null)
            {
                throw new NotFoundException("UserProfile not found.");
            }

            if ((await _unitOfWork.GetReadRepository<UserProfilesRoles>().GetAsync(x => x.RoleId == request.RoleId && x.UserProfileId== request.UserProfileId) is not null))
            {
                throw new BadRequestException("This user profile role is already exists");
            }

            var userProfilerole = new UserProfilesRoles
            {
               RoleId = request.RoleId, 
               UserProfileId = request.UserProfileId,
            };

            await _unitOfWork.GetWriteRepository<UserProfilesRoles>().AddAsync(userProfilerole);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
