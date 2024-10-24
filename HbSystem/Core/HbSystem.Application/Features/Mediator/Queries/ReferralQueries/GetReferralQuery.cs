using HbSystem.Application.Features.Mediator.Results.ReferralResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Queries.ReferralQueries
{
    public class GetReferralQuery:IRequest<List<GetReferralQueryResult>>
    {
    }
}
