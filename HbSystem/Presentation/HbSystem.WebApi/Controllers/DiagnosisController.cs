using HbSystem.Application.Features.Mediator.Commands.DepartmentCommands;
using HbSystem.Application.Features.Mediator.Commands.DiagnosisCommands;
using HbSystem.Application.Features.Mediator.Queries.DepartmentQueries;
using HbSystem.Application.Features.Mediator.Queries.DiagnosisQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HbSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiagnosisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> DiagnosisList()
        {
            var values = await _mediator.Send(new GetDiagnosisQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiagnosis(int id)
        {
            var values = await _mediator.Send(new GetDiagnosisByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiagnosis(CreateDiagnosisCommand command)
        {
            await _mediator.Send(command);
            return Ok("Teşhis Bilgisi eklendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveDiagnosis(RemoveDiagnosisCommand command)
        {
            await _mediator.Send(command);
            return Ok("Teşhis Bilgisi Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiagnosis(UpdateDiagnosisCommand command)
        {
            await _mediator.Send(command);
            return Ok("Teşhis Bilgisi Güncellendi");
        }

        [HttpGet("departmentId/{departmentId}")]
        public async Task<IActionResult> GetDiagnosisDeparmentById (int departmentId)
        {
            var value = await _mediator.Send(new GetDiagnosisByDepartmentIdQuery(departmentId));
            return Ok(value);
        }
    }
}
