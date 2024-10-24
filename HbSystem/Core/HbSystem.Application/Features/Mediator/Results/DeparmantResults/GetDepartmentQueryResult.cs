using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HbSystem.Application.Features.Mediator.Results.DeparmantResults
{
    public class GetDepartmentQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
