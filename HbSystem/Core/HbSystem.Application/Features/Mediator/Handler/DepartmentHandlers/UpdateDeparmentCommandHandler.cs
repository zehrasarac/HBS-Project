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
    public class UpdateDeparmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
    {
        private readonly IRepository<Department> _repository;

        public UpdateDeparmentCommandHandler(IRepository<Department> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
