using MediatR;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Command.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.GetReadRepository<Company>().GetAsync(x=>x.Id==request.Id && !x.IsDeleted);

            company.TIN = request.TIN;
            company.Name = request.Name;
            company.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.GetWriteRepository<Company>().UpdateAsync(company);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
