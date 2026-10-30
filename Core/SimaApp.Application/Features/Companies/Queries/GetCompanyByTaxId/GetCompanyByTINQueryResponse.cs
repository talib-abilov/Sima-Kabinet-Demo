using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Queries.GetCompanyByTaxId
{
    public class GetCompanyByTINQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }
    }
}
