using HbSystem.Application.Features.Mediator.Queries.DepartmentQueries;
using HbSystem.Application.Features.Mediator.Results.DeparmantResults;
using HbSystem.Application.Interfaces;
using HbSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Handler.DepartmentHandlers
{
    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, List<GetDepartmentQueryResult>>
    {
        private readonly IRepository<Department> _repository;

        public GetDepartmentQueryHandler(IRepository<Department> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetDepartmentQueryResult>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetDepartmentQueryResult
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}
