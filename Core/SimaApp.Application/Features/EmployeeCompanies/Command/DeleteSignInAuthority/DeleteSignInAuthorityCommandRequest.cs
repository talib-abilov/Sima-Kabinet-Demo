using MediatR;
using SimaApp.Application.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.DeleteSignIntAuthority
{
    public class DeleteSignIntAuthorityCommandRequest:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
