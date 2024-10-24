using HbSystem.Application.Features.Mediator.Commands.ReferralCommands;
using HbSystem.Application.Interfaces;
using HbSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Handler.ReferralHandlers
{
    public class CreateReferralCommandHandler : IRequestHandler<CreateReferralCommand>
    {
        private readonly IRepository<Referral> _repository;

        public CreateReferralCommandHandler(IRepository<Referral> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReferralCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Referral
            {
                DepartmentId = request.DepartmentId,
                DoctorId = request.DoctorId,
                PatientId = request.PatientId,
                ReferralDate = request.ReferralDate,
            });
        }
    }
}
