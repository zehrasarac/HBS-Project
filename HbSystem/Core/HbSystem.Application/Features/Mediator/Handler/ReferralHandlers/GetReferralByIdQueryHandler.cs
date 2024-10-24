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
    public class GetReferralByIdQueryHandler : IRequestHandler<GetReferralByIdQuery, GetReferralByIdQueryResult>
    {
        private readonly IRepository<Referral> _repository;

        public GetReferralByIdQueryHandler(IRepository<Referral> repository)
        {
            _repository = repository;
        }

        public async Task<GetReferralByIdQueryResult> Handle(GetReferralByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetReferralByIdQueryResult
            {
                DepartmentId = values.DepartmentId,
                DoctorId = values.DoctorId,
                Id = values.Id,
                PatientId = values.PatientId,
                ReferralDate = values.ReferralDate
            };
        }
    }
}
