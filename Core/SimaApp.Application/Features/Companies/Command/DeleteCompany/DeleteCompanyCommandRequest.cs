using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Command.DeleteCompany
{
    public class DeleteCompanyCommandRequest:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
