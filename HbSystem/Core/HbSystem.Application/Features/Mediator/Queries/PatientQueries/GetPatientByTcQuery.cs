using HbSystem.Application.Features.Mediator.Results.PatientResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Queries.PatientQueries
{
    public class GetPatientByTcQuery:IRequest<GetPatientByTcQueryResult>
    {
        public string TcNumber { get; set; }

        public GetPatientByTcQuery(string tcNumber)
        {
            TcNumber = tcNumber;
        }
    }
}
