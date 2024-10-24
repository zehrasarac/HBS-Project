using HbSystem.Application.Features.Mediator.Queries.PatientDiagnosisQueries;
using HbSystem.Application.Features.Mediator.Results.PatientDiagnosisResults;
using HbSystem.Application.Interfaces;
using HbSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Handler.PatientDiagnosisHandlers
{
    public class GetPatientDiagnosesQueryHandler : IRequestHandler<GetPatientDiagnosisQuery, List<GetPatientDiagnosisQueryResult>>
    {
        private readonly IRepository<PatientDiagnosis> _repository;

        public GetPatientDiagnosesQueryHandler(IRepository<PatientDiagnosis> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPatientDiagnosisQueryResult>> Handle(GetPatientDiagnosisQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetPatientDiagnosisQueryResult
            {
                PatientId = x.PatientId,
                ReferralId = x.ReferralId,
                Date = x.Date,
                DiagnosisId = x.DiagnosisId,
                Id = x.Id,
            }).ToList();
        }
    }
}
