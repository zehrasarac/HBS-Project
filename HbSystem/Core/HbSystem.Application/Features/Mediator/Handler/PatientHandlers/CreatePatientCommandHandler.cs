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
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand>
    {
        private readonly IRepository<Patient> _repository;

        public CreatePatientCommandHandler(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
           await _repository.CreateAsync(new Patient
           {
               FirstName = request.FirstName,
               LastName = request.LastName,
               Address = request.Address,
               Phone = request.Phone,
               TcNumber = request.TcNumber,
           });
        }
    }
}
