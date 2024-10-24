using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Results.PatientHistoryResults
{
    public class GetPatientHistoryQueryResult
    {
        public string PatientName { get; set; }
        public string PatientLastName { get; set; }
        public string Department {  get; set; }
        public string Diagnosis { get; set; }
        public string Doctor { get; set; }
        public DateTime ReferralDate { get; set; }
        public DateTime PatientDiagnosisDate { get; set; }
    }
}
