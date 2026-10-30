using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.DeleteUserProfile
{
    public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            var userProfile = await _unitOfWork.GetReadRepository<UserProfile>().GetAsync(x => x.Id == request.Id);
            if (userProfile == null)
            {
                throw new NotFoundException("UserProfile not found");
            }
            userProfile.IsDeleted = true;
            await _unitOfWork.GetWriteRepository<UserProfile>().UpdateAsync(userProfile);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
