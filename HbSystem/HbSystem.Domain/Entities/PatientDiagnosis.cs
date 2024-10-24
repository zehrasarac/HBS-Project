using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Domain.Entities
{
    public class PatientDiagnosis
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int ReferralId { get; set; }

        [Required]
        public int DiagnosisId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public Referral Referral { get; set; }
        public Diagnosis Diagnosis { get; set; }

    }
}
