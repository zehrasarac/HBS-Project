using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Commands.PatientDiagnosisCommands
{
    public class CreatePatientDiagnosisCommand:IRequest
    {
        public int PatientId { get; set; }
        public int ReferralId { get; set; }
        public int DiagnosisId { get; set; }
        public DateTime Date { get; set; }

    }
}
