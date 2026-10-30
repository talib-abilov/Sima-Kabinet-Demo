using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.CreateUserProfile
{
    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.GetReadRepository<User>().GetAsync(x => x.Id == request.UserId && !x.IsDeleted);
            if(user is null)
            {
                throw new NotFoundException("User not found.");
            }

            var company = await _unitOfWork.GetReadRepository<Company>().GetAsync(x => x.Id == request.CompanyId && !x.IsDeleted);
            if (company is null)
            {
                throw new NotFoundException("Company not found.");
            }

            if((await _unitOfWork.GetReadRepository<UserProfile>().GetAsync(x=>x.UserId==request.UserId && x.CompanyId==request.CompanyId) is not null)){
                throw new BadRequestException("This user profile is already exists");
            }

            var userProfile = new UserProfile
            {
                CompanyId = request.CompanyId,
                UserId = request.UserId,
            };

            await _unitOfWork.GetWriteRepository<UserProfile>().AddAsync(userProfile);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;

            

        }
    }
}
