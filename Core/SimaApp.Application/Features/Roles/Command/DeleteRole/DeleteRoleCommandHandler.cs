using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Roles.Command.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.GetReadRepository<Role>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            if(role is null)
            {
                throw new NotFoundException();
            }

            role.IsDeleted = true;
            await _unitOfWork.GetWriteRepository<Role>().UpdateAsync(role);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
