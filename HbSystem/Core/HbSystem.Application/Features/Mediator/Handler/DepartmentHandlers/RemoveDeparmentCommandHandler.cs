using HbSystem.Application.Features.Mediator.Commands.DepartmentCommands;
using HbSystem.Application.Interfaces;
using HbSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Handler.DepartmentHandlers
{
    public class RemoveDeparmentCommandHandler : IRequestHandler<RemoveDepartmentCommand>
    {
        private readonly IRepository<Department> _repository;

        public RemoveDeparmentCommandHandler(IRepository<Department> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveDepartmentCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
