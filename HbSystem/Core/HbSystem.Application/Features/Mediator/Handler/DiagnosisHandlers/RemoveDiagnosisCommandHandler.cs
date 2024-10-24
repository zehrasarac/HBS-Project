using HbSystem.Application.Features.Mediator.Commands.DiagnosisCommands;
using HbSystem.Application.Interfaces;
using HbSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Handler.DiagnosisHandlers
{
    public class RemoveDiagnosisCommandHandler : IRequestHandler<RemoveDiagnosisCommand>
    {
        private readonly IRepository<Diagnosis> _repository;

        public RemoveDiagnosisCommandHandler(IRepository<Diagnosis> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveDiagnosisCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
