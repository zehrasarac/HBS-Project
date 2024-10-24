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
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, GetDepartmentByIdQueryResult>
    {
        private readonly IRepository<Department> _repository;

        public GetDepartmentByIdQueryHandler(IRepository<Department> repository)
        {
            _repository = repository;
        }

        public async Task<GetDepartmentByIdQueryResult> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetDepartmentByIdQueryResult
            {
               Id = values.Id,
               Name = values.Name,
            };
        }
    }
}
