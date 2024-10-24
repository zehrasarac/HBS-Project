using HbSystem.Application.Features.Mediator.Queries.DoctorQueries;
using HbSystem.Application.Features.Mediator.Results.DoctorResults;
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
    public class GetDoctorQueryHandler : IRequestHandler<GetDoctorQuery, List<GetDoctorQueryResult>>
    {
        private readonly IRepository<Doctor> _repository;

        public GetDoctorQueryHandler(IRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetDoctorQueryResult>> Handle(GetDoctorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetDoctorQueryResult
            {
                DepartmentId = x.Id,
                FirstName =x.FirstName,
                LastName = x.LastName,
                Id = x.Id,
            }).ToList();
        }
    }
}
