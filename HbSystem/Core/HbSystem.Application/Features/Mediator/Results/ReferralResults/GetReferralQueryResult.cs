﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Results.ReferralResults
{
    public class GetReferralQueryResult
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public DateTime ReferralDate { get; set; }

    }
}
