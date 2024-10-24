using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Domain.Entities
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(11,MinimumLength = 11)]
        public string TcNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(15)]
        public string Phone {  get; set; }

        public List<PatientDiagnosis> PatientDiagnoses { get; set; }
        public List<Referral> Referrals { get; set; }
    }
}
