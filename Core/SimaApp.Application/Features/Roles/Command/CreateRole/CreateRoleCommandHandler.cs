using MediatR;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Roles.Command.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = new Role
            {
                Name = request.Name,
                Description = request.Description,
            };
            await _unitOfWork.GetWriteRepository<Role>().AddAsync(role);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
