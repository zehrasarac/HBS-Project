using HbSystem.Application.Features.Mediator.Results.DiagnosisResults;
using HbSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Queries.DiagnosisQueries
{
    public class GetDiagnosisByDepartmentIdQuery:IRequest<List<GetDiagnosisByDepartmentIdQueryResult>>
    {
        public int DepartmentId { get; set; }

        public GetDiagnosisByDepartmentIdQuery(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}
