using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Queries.IsCompanyExists
{
    public class IsCompanyExsistsQueryRequest:IRequest<IsCompanyExistsQueryResponse>
    {
        public string TIN {  get; set; }
    }
}
