using HbSystem.Application.Features.Mediator.Queries.ReferralQueries;
using HbSystem.Application.Features.Mediator.Results.ReferralResults;
using HbSystem.Application.Interfaces;
using HbSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Handler.ReferralHandlers
{
    public class GetReferralQueryHandler : IRequestHandler<GetReferralQuery, List<GetReferralQueryResult>>
    {
        private readonly IRepository<Referral> _repository;

        public GetReferralQueryHandler(IRepository<Referral> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReferralQueryResult>> Handle(GetReferralQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetReferralQueryResult
            {
                DepartmentId = x.DepartmentId,
                DoctorId = x.DoctorId,
                Id = x.Id,
                PatientId = x.PatientId,
                ReferralDate = x.ReferralDate,
            }).ToList();
        }
    }
}
