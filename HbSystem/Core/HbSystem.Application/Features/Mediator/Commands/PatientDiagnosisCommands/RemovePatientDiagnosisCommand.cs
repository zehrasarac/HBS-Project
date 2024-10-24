using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Commands.PatientDiagnosisCommands
{
    public class RemovePatientDiagnosisCommand:IRequest
    {
        public int Id { get; set; }

        public RemovePatientDiagnosisCommand(int id)
        {
            Id = id;
        }
    }
}
