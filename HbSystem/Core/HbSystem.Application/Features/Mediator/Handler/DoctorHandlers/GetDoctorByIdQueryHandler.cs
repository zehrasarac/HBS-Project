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
    public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, GetDoctorByIdQueryResult>
    {
        private readonly IRepository<Doctor> _repository;

        public GetDoctorByIdQueryHandler(IRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public async Task<GetDoctorByIdQueryResult> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetDoctorByIdQueryResult
            {
                Id = values.Id,
                DepartmentId = values.DepartmentId,
                FirstName= values.FirstName,
                LastName = values.LastName,
            };
        }
    }
}
