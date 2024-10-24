using HbSystem.Application.Features.Mediator.Commands.PatientDiagnosisCommands;
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
    public class CreatePatientDiagnosesCommandHandler : IRequestHandler<CreatePatientDiagnosisCommand>
    {
        private readonly IRepository<PatientDiagnosis> _repository;

        public CreatePatientDiagnosesCommandHandler(IRepository<PatientDiagnosis> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatePatientDiagnosisCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new PatientDiagnosis
            {
                PatientId = request.PatientId,
                ReferralId = request.ReferralId,
                DiagnosisId = request.DiagnosisId,
                Date = request.Date == default ? DateTime.Now : request.Date
            });
        }
    }
}
