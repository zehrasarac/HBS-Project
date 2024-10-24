using HbSystem.Application.Features.Mediator.Queries.PatientQueries;
using HbSystem.Application.Features.Mediator.Results.DoctorResults;
using HbSystem.Application.Features.Mediator.Results.PatientResults;
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
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, GetPatientByIdQueryResult>
    {
        private readonly IRepository<Patient> _repository;

        public GetPatientByIdQueryHandler(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task<GetPatientByIdQueryResult> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetPatientByIdQueryResult
            {
               Id = values.Id,
               Address = values.Address,
               FirstName = values.FirstName,
               LastName = values.LastName,
               Phone = values.Phone,
               TcNumber = values.TcNumber,

            };
        }
    }
}
