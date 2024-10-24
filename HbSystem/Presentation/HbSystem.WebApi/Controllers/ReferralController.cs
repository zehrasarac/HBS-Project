using HbSystem.Application.Features.Mediator.Commands.ReferralCommands;
using HbSystem.Application.Features.Mediator.Queries.ReferralQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HbSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferralController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReferralController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ReferralList()
        {
            var values = await _mediator.Send(new GetReferralQuery());
            return Ok(values);
        } 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReferral(int id)
        {
            var values = await _mediator.Send(new GetReferralByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReferral(CreateReferralCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sevk Bilgisi Eklendi");
        }

        [HttpGet("tc/{tcNumber}")]
        public async Task<IActionResult> GetReferralByTcNumber(string tcNumber)
        {
            var response = await _mediator.Send(new GetReferralByTcNumberQuery(tcNumber));
            if (response == null)
            {
                return NotFound("Sevk bilgisi bulunamadı.");
            }
            return Ok(response);
        }
    }
}
