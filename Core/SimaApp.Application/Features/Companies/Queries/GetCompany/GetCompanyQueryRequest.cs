using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Queries.GetCompany
{
    public class GetCompanyQueryRequest:IRequest<GetCompanyQueryResponse>
    {
        public int Id { get; set; }
        public GetCompanyQueryRequest(int id)
        {
            Id = id;
        }
    }
}
