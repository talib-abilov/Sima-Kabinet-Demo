using MediatR;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Queries.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, IList<GetAllUserQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllUserQueryResponse>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.GetReadRepository<User>().GetAllAsync();

            List<GetAllUserQueryResponse> response = new();

            foreach(var item in users)
            {
                response.Add(new GetAllUserQueryResponse
                {
                    Id = item.Id,
                    Email = item.Email,
                    EmployeeId = item.EmployeeId
                });
            }

            return response;
        }
    }
}
