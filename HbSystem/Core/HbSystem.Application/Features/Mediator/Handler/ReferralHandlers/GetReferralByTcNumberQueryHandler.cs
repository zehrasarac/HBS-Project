using HbSystem.Application.Features.Mediator.Queries.ReferralQueries;
using HbSystem.Application.Features.Mediator.Results.PatientResults;
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
    public class GetReferralByTcNumberQueryHandler : IRequestHandler<GetReferralByTcNumberQuery, GetReferralByTcNumberQueryResult>
    {
        private readonly IRepository<Referral> _repository;
        private readonly IRepository<Patient> _patientRepository;

        public GetReferralByTcNumberQueryHandler(IRepository<Referral> repository, IRepository<Patient> patientRepository)
        {
            _repository = repository;
            _patientRepository = patientRepository;
        }

        public async Task<GetReferralByTcNumberQueryResult> Handle(GetReferralByTcNumberQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetAllAsync();
            var foundPatient = patient.FirstOrDefault(p=>p.TcNumber == request.TcNumber);

            if (foundPatient != null) {
                var referral = await _repository.GetAllAsync();
                var foundReferral = referral.FirstOrDefault(r => r.PatientId == foundPatient.Id);

                if (foundReferral != null) {
                    return new GetReferralByTcNumberQueryResult
                    {
                        PatientId = foundReferral.PatientId,
                        DepartmentId = foundReferral.DepartmentId,
                        DoctorId = foundReferral.DoctorId,
                        Id = foundReferral.Id,
                        ReferralDate = foundReferral.ReferralDate,
                    };
                }
            }
            return null;
        }
    }
}
