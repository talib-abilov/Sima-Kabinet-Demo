using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Command.UpdateCompany
{
    public class UpdateCompanyCommandRequest:IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TIN { get; set; }
    }
}
