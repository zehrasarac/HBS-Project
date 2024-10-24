using HbSystem.Application.Features.Mediator.Results.DeparmantResults;
using HbSystem.Application.Features.Mediator.Results.DiagnosisResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Queries.DiagnosisQueries
{
    public class GetDiagnosisByIdQuery:IRequest<GetDiagnosisByIdQueryResult>
    {
        public int Id { get; set; }

        public GetDiagnosisByIdQuery(int id)
        {
            Id = id;
        }
    }
}
