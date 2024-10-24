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
    public class UpdatePatientDiagnosesCommandHandler : IRequestHandler<UpdatePatientDiagnosisCommand>
    {
        private readonly IRepository<PatientDiagnosis> _repository;

        public UpdatePatientDiagnosesCommandHandler(IRepository<PatientDiagnosis> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePatientDiagnosisCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.DiagnosisId = request.Id;
            values.Date = request.Date;
            values.PatientId = request.PatientId;
            values.ReferralId = request.ReferralId;
            await _repository.UpdateAsync(values);
        }
    }
}
