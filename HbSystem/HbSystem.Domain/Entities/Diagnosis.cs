using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Domain.Entities
{
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public List<PatientDiagnosis> PatientDiagnoses { get; set;}

    }
}
