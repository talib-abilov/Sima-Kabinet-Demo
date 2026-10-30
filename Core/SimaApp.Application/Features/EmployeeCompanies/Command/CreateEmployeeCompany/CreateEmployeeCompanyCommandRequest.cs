using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.CreateEmployeeCompany
{
    public class CreateEmployeeCompanyCommandRequest:IRequest<Unit>
    {
        public string Position { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fullname { get; set; }
        //public string PatronymicName { get; set; }
        public string PIN { get; set; }
        //public string Serial { get; set; }
        //public int SerialNumber { get; set; }
        public int CompanyId { get; set; }
    }
}
