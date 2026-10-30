using SimaApp.Application.Bases;
using SimaApp.Application.Features.Companies.Exceptions;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Rules
{
    public class CompanyRules:BaseRules
    {
        public Task CompanyNameMustBeUnique(IList<Company> companies,string companyName)
        {
            if (companies.Any(x => x.Name.ToLower() == companyName.ToLower()))
                throw new CompanyNameMustBeUniqueException();
            return Task.CompletedTask;
        }
    }
}
