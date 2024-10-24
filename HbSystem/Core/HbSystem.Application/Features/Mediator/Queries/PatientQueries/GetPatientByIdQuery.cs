using HbSystem.Application.Features.Mediator.Results.PatientResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Queries.PatientQueries
{
    public class GetPatientByIdQuery:IRequest<GetPatientByIdQueryResult>
    {
        public int Id { get; set; }

        public GetPatientByIdQuery(int id)
        {
            Id = id;
        }
    }
}
