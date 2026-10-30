using SimaApp.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Exceptions
{
    public class CompanyNameMustBeUniqueException : BaseExceptions
    {
        public CompanyNameMustBeUniqueException():base("Company with this name already exists.")
        {
            
        }
    }
}
