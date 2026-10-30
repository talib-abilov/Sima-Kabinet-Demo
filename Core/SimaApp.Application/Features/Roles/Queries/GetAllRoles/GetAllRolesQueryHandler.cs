using MediatR;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQueryRequest, IList<GetAllRolesQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRolesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllRolesQueryResponse>> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = await _unitOfWork.GetReadRepository<Role>().GetAllAsync(x=>x.IsDeleted==false);

            List<GetAllRolesQueryResponse> response = new();

            foreach(var item in roles)
            {
                response.Add(new GetAllRolesQueryResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                });
            }
            return response;
        }
    }
}
