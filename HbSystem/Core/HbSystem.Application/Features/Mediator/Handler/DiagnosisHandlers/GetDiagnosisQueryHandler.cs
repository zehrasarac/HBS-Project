using HbSystem.Application.Features.Mediator.Queries.DiagnosisQueries;
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
    public class GetDiagnosisQueryHandler : IRequestHandler<GetDiagnosisQuery, List<GetDiagnosisQueryResult>>
    {
        private readonly IRepository<Diagnosis> _repository;

        public GetDiagnosisQueryHandler(IRepository<Diagnosis> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetDiagnosisQueryResult>> Handle(GetDiagnosisQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetDiagnosisQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                DepartmentId = x.DepartmentId,
            }).ToList();
        }
    }
}
