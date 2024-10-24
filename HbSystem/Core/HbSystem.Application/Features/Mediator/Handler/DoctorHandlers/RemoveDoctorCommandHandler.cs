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
    public class RemoveDoctorCommandHandler : IRequestHandler<RemoveDoctorCommand>
    {
        private readonly IRepository<Doctor> _repository;

        public RemoveDoctorCommandHandler(IRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveDoctorCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
