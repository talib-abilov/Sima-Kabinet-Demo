using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Queries.GetUserProfile
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQueryRequest, GetUserProfileQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserProfileQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetUserProfileQueryResponse> Handle(GetUserProfileQueryRequest request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.GetReadRepository<Employee>().GetAsync(x=>x.EmployeeDocument.PIN==request.PIN);
            if(employee is null)
            {
                throw new NotFoundException("Employee tapilmadi");
            }
            var company = await _unitOfWork.GetReadRepository<Company>().GetAsync(x => x.TIN == request.TIN);
            if (company is null)
            {
                throw new NotFoundException("Şirkət tapilmadi");
            }
            var user = await _unitOfWork.GetReadRepository<User>().GetAsync(x => x.EmployeeId == employee.Id);
            if(user is null)
            {
                throw new NotFoundException("İstifadəçi tapilmadi");
            }
            var userProfile = await _unitOfWork.GetReadRepository<UserProfile>().GetAsync(x=>x.UserId==user.Id && x.CompanyId==company.Id);
            if(userProfile is null)
            {
                throw new NotFoundException("UserProfile tapılmadı");
            }
            GetUserProfileQueryResponse response = new GetUserProfileQueryResponse()
            {
                Id = userProfile.Id,
                CompanyId = userProfile.CompanyId,
                UserId = userProfile.CompanyId,
            };
           
            return response;
        }
    }
}
