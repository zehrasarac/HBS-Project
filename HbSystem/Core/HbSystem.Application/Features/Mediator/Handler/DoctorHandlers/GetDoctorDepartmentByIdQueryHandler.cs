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
    public class GetDoctorDepartmentByIdQueryHandler : IRequestHandler<GetDoctorByDepartmentIdQuery, List<GetDoctorByDepartmentIdQueryResult>>
    {
        private readonly IRepository<Doctor> _repository;

        public GetDoctorDepartmentByIdQueryHandler(IRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetDoctorByDepartmentIdQueryResult>> Handle(GetDoctorByDepartmentIdQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _repository.GetAllAsync();
            var filteredDoctors = doctors.Where(p=>p.DepartmentId == request.DepartmentId).ToList();

            var value = filteredDoctors.Select(doctor => new GetDoctorByDepartmentIdQueryResult
            {
                DepartmentId = doctor.DepartmentId,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Id = doctor.Id,
            }).ToList();

            return value;
        }
    }
}
