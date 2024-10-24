using HbSystem.Application.Features.Mediator.Commands.DepartmentCommands;
using HbSystem.Application.Features.Mediator.Commands.PatientDiagnosisCommands;
using HbSystem.Application.Features.Mediator.Queries.DepartmentQueries;
using HbSystem.Application.Features.Mediator.Queries.PatientDiagnosisQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HbSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDiagnosisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientDiagnosisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PatientDiagnosisList()
        {
            var values = await _mediator.Send(new GetPatientDiagnosisQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientDiagnosis(int id)
        {
            var values = await _mediator.Send(new GetPatientDiagnosisByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatientDiagnosis(CreatePatientDiagnosisCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hasta Teşhisi Bilgisi eklendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemovePatientDiagnosis(RemovePatientDiagnosisCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hasta Teşhisi Bilgisi Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatientDiagnosis(UpdatePatientDiagnosisCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hasta Teşhisi Bilgisi Güncellendi");
        }
    }
}
