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
    public class CreateDeparmentCommandHandler : IRequestHandler<CreateDepartmentCommand>
    {
        private readonly IRepository<Department> _repository;

        public CreateDeparmentCommandHandler(IRepository<Department> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Department
            {
                Name = request.Name,
            });
        }
    }
}
