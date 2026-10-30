using MediatR;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.GetReadRepository<User>().GetAsync(x=>x.Employee.Id==request.EmployeeId);
            if(user is not null)
            {
                throw new Exception("Bu istifadəçi mövcuddur.");
            }

            var newUser = new User
            {
                Email = request.Email,
                EmployeeId = request.EmployeeId,
            };

            await _unitOfWork.GetWriteRepository<User>().AddAsync(newUser);
         

            await _unitOfWork.SaveChangesAsync();
                       

            return Unit.Value;
        }
    }
}
