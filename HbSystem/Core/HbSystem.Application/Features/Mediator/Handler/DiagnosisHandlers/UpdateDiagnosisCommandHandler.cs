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
    public class UpdateDiagnosisCommandHandler : IRequestHandler<UpdateDiagnosisCommand>
    {
        private readonly IRepository<Diagnosis> _repository;

        public UpdateDiagnosisCommandHandler(IRepository<Diagnosis> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateDiagnosisCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Name = request.Name;
            values.DepartmentId = request.DepartmentId;
            await _repository.UpdateAsync(values);
        }
    }
}
