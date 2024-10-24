using HbSystem.Application.Features.Mediator.Queries.DepartmentQueries;
using HbSystem.Application.Features.Mediator.Queries.DiagnosisQueries;
using HbSystem.Application.Features.Mediator.Queries.DoctorQueries;
using HbSystem.Application.Features.Mediator.Results.DeparmantResults;
using HbSystem.Application.Features.Mediator.Results.DiagnosisResults;
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
    public class GetDiagnosisByIdQueryHandler : IRequestHandler<GetDiagnosisByIdQuery, GetDiagnosisByIdQueryResult>
    {
        private readonly IRepository<Diagnosis> _repository;

        public GetDiagnosisByIdQueryHandler(IRepository<Diagnosis> repository)
        {
            _repository = repository;
        }

        public async Task<GetDiagnosisByIdQueryResult> Handle(GetDiagnosisByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetDiagnosisByIdQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                DepartmentId = values.DepartmentId,
            };
        }
    }
}
