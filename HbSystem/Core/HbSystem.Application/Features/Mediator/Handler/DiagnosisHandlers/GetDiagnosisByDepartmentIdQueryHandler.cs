using HbSystem.Application.Features.Mediator.Queries.DiagnosisQueries;
using HbSystem.Application.Features.Mediator.Results.DiagnosisResults;
using HbSystem.Application.Features.Mediator.Results.DoctorResults;
using HbSystem.Application.Interfaces;
using HbSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Handler.DiagnosisHandlers
{
    public class GetDiagnosisByDepartmentIdQueryHandler : IRequestHandler<GetDiagnosisByDepartmentIdQuery, List<GetDiagnosisByDepartmentIdQueryResult>>
    {
        private readonly IRepository<Diagnosis> _repository;

        public GetDiagnosisByDepartmentIdQueryHandler(IRepository<Diagnosis> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetDiagnosisByDepartmentIdQueryResult>> Handle(GetDiagnosisByDepartmentIdQuery request, CancellationToken cancellationToken)
        {
            var diagnosis = await _repository.GetAllAsync();
            var filteredDiagnoseses = diagnosis.Where(p => p.DepartmentId == request.DepartmentId).ToList();

            var value = filteredDiagnoseses.Select(diagnosis => new GetDiagnosisByDepartmentIdQueryResult
            {
                DepartmentId = diagnosis.DepartmentId,
                Id = diagnosis.Id,
                Name = diagnosis.Name,
            }).ToList();

            return value;
        }
    }
}
