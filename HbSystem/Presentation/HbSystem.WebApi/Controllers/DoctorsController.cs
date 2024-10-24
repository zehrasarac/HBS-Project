using HbSystem.Application.Features.Mediator.Commands.DoctorCommands;
using HbSystem.Application.Features.Mediator.Queries.DoctorQueries;
using HbSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HbSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> DoctorList()
        {
            var values = await _mediator.Send(new GetDoctorQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var value = await _mediator.Send(new GetDoctorByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Doctor Bilgisi Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveDoctor(int id)
        {
            await _mediator.Send(new RemoveDoctorCommand(id));
            return Ok("Doktor Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Doktor Bilgisi Güncellendi");
        }

        [HttpGet("departmentId/{departmentId}")]
        public async Task<IActionResult> GetDoctorDepartmentById (int departmentId) 
        {
            var value = await _mediator.Send(new GetDoctorByDepartmentIdQuery(departmentId));
            return Ok(value);
        }
    }
}
