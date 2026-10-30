using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.Features.Users.Command.DeleteUSer;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.GetReadRepository<User>().GetAsync(x => x.Id == request.Id);
            if(user is null)
            {
                throw new NotFoundException("User not found.");
            }
            user.IsDeleted = true;
            await _unitOfWork.GetWriteRepository<User>().UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
