using HbSystem.Application.Features.Mediator.Results.PatientDiagnosisResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Queries.PatientDiagnosisQueries
{
    public class GetPatientDiagnosisByIdQuery:IRequest<GetPatientDiagnosisByIdQueryResult>
    {
        public int Id { get; set; }

        public GetPatientDiagnosisByIdQuery(int id)
        {
            Id = id;
        }
    }
}
