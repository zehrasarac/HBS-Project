using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Commands.DiagnosisCommands
{
    public class RemoveDiagnosisCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveDiagnosisCommand(int id)
        {
            Id = id;
        }
    }
}
