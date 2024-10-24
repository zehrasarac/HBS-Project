using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Domain.Entities
{
    public class Referral
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime ReferralDate { get; set; }



        public Patient Patient { get; set; }
        public Department Department { get; set; }
        public Doctor Doctor { get; set; }

        public List<PatientDiagnosis> PatientDiagnosis { get; set; }

    }
}
