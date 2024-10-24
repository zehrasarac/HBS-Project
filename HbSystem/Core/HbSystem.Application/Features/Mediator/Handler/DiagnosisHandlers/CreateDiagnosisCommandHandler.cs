using HbSystem.Application.Features.Mediator.Commands.DiagnosisCommands;
using HbSystem.Application.Features.Mediator.Queries.DiagnosisQueries;
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
    public class CreateDiagnosisCommandHandler : IRequestHandler<CreateDiagnosisCommand>
    {
        private readonly IRepository<Diagnosis> _repository;

        public CreateDiagnosisCommandHandler(IRepository<Diagnosis> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateDiagnosisCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Diagnosis
            {
                Name = request.Name,
                DepartmentId = request.DepartmentId,
            });
        }
    }
}
