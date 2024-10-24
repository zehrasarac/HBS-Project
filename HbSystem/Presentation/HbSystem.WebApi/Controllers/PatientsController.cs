using HbSystem.Application.Features.Mediator.Commands.DoctorCommands;
using HbSystem.Application.Features.Mediator.Commands.PatientCommands;
using HbSystem.Application.Features.Mediator.Queries.DoctorQueries;
using HbSystem.Application.Features.Mediator.Queries.PatientQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HbSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> PatientList()
        {
            var values = await _mediator.Send(new GetPatientQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var value = await _mediator.Send(new GetPatientByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("tc/{tcNumber}")]
        public async Task<IActionResult> GetPatientByTc(string tcNumber)
        {
           var value = await _mediator.Send(new GetPatientByTcQuery(tcNumber));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient(CreatePatientCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hasta Bilgisi Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemovePatient(int id)
        {
            await _mediator.Send(new RemovePatientCommand(id));
            return Ok("Hasta Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePatient(UpdatePatientCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hasta Bilgisi Güncellendi");
        }
    }
}
