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
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand>
    {
        private readonly IRepository<Doctor> _repository;

        public CreateDoctorCommandHandler(IRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Doctor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DepartmentId = request.DepartmentId,
            });
        }
    }
}
