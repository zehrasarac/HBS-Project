using HbSystem.Application.Features.Mediator.Queries.PatientHistoryQueries;
using HbSystem.Application.Features.Mediator.Results.PatientHistoryResults;
using HbSystem.Application.Interfaces;
using HbSystem.Domain.Entities;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Handler.PatientHistoryHandlers
{
    public class GetPatientHistoryQueryHandler : IRequestHandler<GetPatientHistoryQuery, List<GetPatientHistoryQueryResult>>
    {
        private readonly IRepository<PatientDiagnosis> _repository;

        public GetPatientHistoryQueryHandler(IRepository<PatientDiagnosis> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPatientHistoryQueryResult>> Handle(GetPatientHistoryQuery request, CancellationToken cancellationToken)
        {
            var patientDiagnoses = await _repository.GetByTcAsync(request.PatientTc);


            if (patientDiagnoses == null || !patientDiagnoses.Any())
            {
                throw new InvalidOperationException($"No diagnoses found for patient with ID {request.PatientTc}");
            }

            var result = patientDiagnoses.Select(pd => new GetPatientHistoryQueryResult
            {
                PatientName = pd.Referral.Patient?.FirstName ?? "Hasta bilgisi yok",
                PatientLastName = pd.Referral.Patient?.LastName ?? "Hasta bilgisi yok",
                Department = pd.Referral.Department?.Name,
                Diagnosis = pd.Diagnosis?.Name ?? "Tanı bilgisi yok",
                Doctor = $"{pd.Referral.Doctor?.FirstName} {pd.Referral.Doctor?.LastName}" ?? "Doktor bilgisi yok",
                ReferralDate = pd.Referral.ReferralDate,
                PatientDiagnosisDate = pd.Date,
            }).ToList();

            return result;
        }
    }
}
