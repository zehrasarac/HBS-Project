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
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
    {
        private readonly IRepository<Patient> _repository;

        public UpdatePatientCommandHandler(IRepository<Patient> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.TcNumber = request.TcNumber;
            values.Address = request.Address;
            values.FirstName = request.FirstName;
            values.LastName = request.LastName;
            values.Phone = request.Phone;
            await _repository.UpdateAsync(values);
        }
    }
}
