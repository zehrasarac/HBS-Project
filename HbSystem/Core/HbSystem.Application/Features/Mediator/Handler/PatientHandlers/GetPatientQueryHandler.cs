using HbSystem.Application.Features.Mediator.Handler.DoctorHandlers;
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
    public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, List<GetPatientQueryResult>>
    {
        private readonly IRepository<Patient> _repository;

        public GetPatientQueryHandler(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPatientQueryResult>> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetPatientQueryResult
            {
                Id = x.Id,
                Address = x.Address,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Phone = x.Phone,
                TcNumber = x.TcNumber,
            }).ToList();
        }
    }
}
