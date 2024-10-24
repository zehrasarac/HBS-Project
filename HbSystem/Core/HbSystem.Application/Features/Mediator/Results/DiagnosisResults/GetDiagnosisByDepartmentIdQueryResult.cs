﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Results.DiagnosisResults
{
    public class GetDiagnosisByDepartmentIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}