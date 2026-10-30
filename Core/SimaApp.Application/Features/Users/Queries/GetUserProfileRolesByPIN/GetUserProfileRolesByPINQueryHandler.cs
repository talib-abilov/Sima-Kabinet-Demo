using MediatR;
using Microsoft.EntityFrameworkCore;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Queries.GetUserProfileRolesByPIN
{
    public class GetUserProfileRolesByPINQueryHandler : IRequestHandler<GetUserProfileRolesByPINQueryRequest, IList<GetUserProfileRolesByPINQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserProfileRolesByPINQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<GetUserProfileRolesByPINQueryResponse>> Handle(GetUserProfileRolesByPINQueryRequest request, CancellationToken cancellationToken)
        {
            var userProfileRoles = await _unitOfWork.GetReadRepository<UserProfilesRoles>().GetAllAsync(x => x.UserProfile.User.Employee.EmployeeDocument.PIN == request.PIN,query=>query.Include(x=>x.UserProfile).Include(x=>x.Role));


            List<GetUserProfileRolesByPINQueryResponse> response = new();

            foreach (var item in userProfileRoles)
            {
                response.Add(new GetUserProfileRolesByPINQueryResponse
                {
                    Id = item.Id,
                    UserProfileId = item.UserProfileId,
                    RoleId = item.RoleId,

                });
            }

            return response;
        }
    }
}
