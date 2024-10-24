using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Commands.DepartmentCommands
{
    public class UpdateDepartmentCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
