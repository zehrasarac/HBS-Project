using HbSystem.Application.Features.Mediator.Commands.DoctorCommands;
using HbSystem.Application.Interfaces;
using HbSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Handler.DoctorHandlers
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand>
    {
        private readonly IRepository<Doctor> _repository;

        public UpdateDoctorCommandHandler(IRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.FirstName = request.FirstName;
            values.LastName = request.LastName;
            values.DepartmentId = request.DepartmentId;
            await _repository.UpdateAsync(values);
        }
    }
}
