using HbSystem.Application.Features.Mediator.Results.PatientHistoryResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Queries.PatientHistoryQueries
{
    public class GetPatientHistoryQuery:IRequest<List<GetPatientHistoryQueryResult>>
    {
        public string PatientTc { get; set; }

        
    }
}
