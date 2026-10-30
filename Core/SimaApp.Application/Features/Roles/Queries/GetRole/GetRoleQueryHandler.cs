using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Roles.Queries.GetRole
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQueryRequest, GetRoleQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRoleQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetRoleQueryResponse> Handle(GetRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.GetReadRepository<Role>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            if(role is null)
            {
                throw new NotFoundException();
            }

            var response = new GetRoleQueryResponse
            {
                Name = role.Name,
                Description = role.Description
            };
            return response;

        }
    }
}
