using HbSystem.Application.Features.Mediator.Queries.PatientQueries;
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
    public class GetPatientByTcQueryHandler : IRequestHandler<GetPatientByTcQuery, GetPatientByTcQueryResult>
    {
        private readonly IRepository<Patient> _repository;

        public GetPatientByTcQueryHandler(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task<GetPatientByTcQueryResult> Handle(GetPatientByTcQuery request, CancellationToken cancellationToken)
        {
            var patient = await _repository.GetAllAsync();
            var values = patient.FirstOrDefault(p=>p.TcNumber == request.TcNumber);

            if (values != null) 
            {
                return new GetPatientByTcQueryResult
                {
                    TcNumber = values.TcNumber,
                    Address = values.Address,
                    FirstName = values.FirstName,
                    LastName = values.LastName,
                    Id = values.Id,
                    Phone = values.Phone
                };
            }
            return null;
        }
    }
}
