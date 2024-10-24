using HbSystem.Application.Features.Mediator.Results.DoctorResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Queries.DoctorQueries
{
    public class GetDoctorQuery:IRequest<List<GetDoctorQueryResult>>
    {
    }
}
