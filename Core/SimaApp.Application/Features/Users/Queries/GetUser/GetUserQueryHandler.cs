using MediatR;
using SendGrid.Helpers.Errors.Model;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GetUserQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetUserQueryResponse> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.GetReadRepository<User>().GetAsync(x=>x.Id==request.Id);
            if(user is null)
            {
                throw new NotFoundException();
            }
            var response = new GetUserQueryResponse
            {
                Email=user.Email,
                EmployeeId=user.EmployeeId
            };
            return response;
        }
    }
}
