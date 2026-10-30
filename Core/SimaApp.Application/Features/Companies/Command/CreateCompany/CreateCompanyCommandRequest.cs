using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Command.CreateProduct
{
    public class CreateCompanyCommandRequest:IRequest<Unit>
    {
        public string Name { get; set; }
        public string TIN { get; set; }
    }
}
