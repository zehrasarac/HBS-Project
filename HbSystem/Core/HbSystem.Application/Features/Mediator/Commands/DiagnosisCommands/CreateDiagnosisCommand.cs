using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Commands.DiagnosisCommands
{
    public class CreateDiagnosisCommand:IRequest
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
