using HbSystem.Application.Features.Mediator.Results.PatientDiagnosisResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Queries.PatientDiagnosisQueries
{
    public class GetPatientDiagnosisQuery:IRequest<List<GetPatientDiagnosisQueryResult>>
    {
    }
}
