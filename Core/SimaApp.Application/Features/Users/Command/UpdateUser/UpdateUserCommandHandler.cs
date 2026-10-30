using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.GetReadRepository<User>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            if(user is null)
            {
                throw new NotFoundException("User not found.");
            }

            user.Email = request.Email;
            user.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _unitOfWork.GetWriteRepository<User>().UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
