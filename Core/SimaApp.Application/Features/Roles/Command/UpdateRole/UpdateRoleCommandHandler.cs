using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Roles.Command.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.GetReadRepository<Role>().GetAsync(x => x.Id == request.Id);
            if(role is null)
            {
                throw new NotFoundException();
            }

            role.Name= request.Name;
            role.Description = request.Description;
            role.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.GetWriteRepository<Role>().UpdateAsync(role);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
