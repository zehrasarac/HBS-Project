using HbSystem.Application.Features.Mediator.Commands.PatientCommands;
using HbSystem.Application.Interfaces;
using HbSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Handler.PatientHandlers
{
    public class RemovePaetientCommandHandler : IRequestHandler<RemovePatientCommand>
    {
        private readonly IRepository<Patient> _repository;

        public RemovePaetientCommandHandler(IRepository<Patient> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemovePatientCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
