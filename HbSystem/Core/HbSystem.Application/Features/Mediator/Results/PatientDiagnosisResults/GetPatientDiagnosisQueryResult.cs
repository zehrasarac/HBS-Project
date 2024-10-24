using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Results.PatientDiagnosisResults
{
    public class GetPatientDiagnosisQueryResult
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int ReferralId { get; set; }
        public int DiagnosisId { get; set; }
        public DateTime Date { get; set; }
    }

}
