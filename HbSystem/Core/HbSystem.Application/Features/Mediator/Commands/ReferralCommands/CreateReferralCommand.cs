using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Commands.ReferralCommands
{
    public class CreateReferralCommand:IRequest
    {
        public int PatientId { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public DateTime ReferralDate { get; set; }
    }
}
