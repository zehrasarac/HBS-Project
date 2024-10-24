using HbSystem.Application.Features.Mediator.Commands.DepartmentCommands;
using HbSystem.Application.Features.Mediator.Queries.DepartmentQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HbSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> DepartmentList()
        {
            var values = await _mediator.Send(new GetDepartmentQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var values = await _mediator.Send(new GetDepartmentByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Departman Bilgisi eklendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveDepartment(RemoveDepartmentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Departman Bilgisi Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Departman Bilgisi Güncellendi");
        }
    }
}
