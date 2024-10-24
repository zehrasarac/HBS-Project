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
    public class RemovePatientDiagnosesCommandHandler : IRequestHandler<RemovePatientDiagnosisCommand>
    {
        private readonly IRepository<PatientDiagnosis> _repository;

        public RemovePatientDiagnosesCommandHandler(IRepository<PatientDiagnosis> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemovePatientDiagnosisCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
