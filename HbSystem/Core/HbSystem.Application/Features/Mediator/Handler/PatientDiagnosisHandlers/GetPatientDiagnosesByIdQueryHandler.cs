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
    public class GetPatientDiagnosesByIdQueryHandler : IRequestHandler<GetPatientDiagnosisByIdQuery, GetPatientDiagnosisByIdQueryResult>
    {
        private readonly IRepository<PatientDiagnosis> _repository;

        public GetPatientDiagnosesByIdQueryHandler(IRepository<PatientDiagnosis> repository)
        {
            _repository = repository;
        }

        public async Task<GetPatientDiagnosisByIdQueryResult> Handle(GetPatientDiagnosisByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetPatientDiagnosisByIdQueryResult { 
                Date = values.Date,
                PatientId = values.PatientId,
                DiagnosisId = values.DiagnosisId,
                ReferralId = values.ReferralId,
                Id = values.Id
            };
        }
    }
}
