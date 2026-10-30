using MediatR;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Command.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommandRequest,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.GetReadRepository<Company>().GetAsync(x=>x.Id==request.Id && !x.IsDeleted);
            company.IsDeleted = true;

            await _unitOfWork.GetWriteRepository<Company>().UpdateAsync(company);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
