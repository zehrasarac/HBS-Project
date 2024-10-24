using HbSystem.Application.Features.Mediator.Results.DeparmantResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Queries.DepartmentQueries
{
    public class GetDepartmentByIdQuery:IRequest<GetDepartmentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetDepartmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
