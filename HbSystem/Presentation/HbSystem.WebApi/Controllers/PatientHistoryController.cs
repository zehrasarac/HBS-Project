using HbSystem.Application.Features.Mediator.Queries.PatientHistoryQueries;
using HbSystem.Application.Features.Mediator.Results.PatientHistoryResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HbSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{patientId}")]
        public async Task<ActionResult<List<GetPatientHistoryQueryResult>>> GetPatientHistory(string patientId)
        {
            var query = new GetPatientHistoryQuery { PatientTc = patientId };
            var result = await _mediator.Send(query);

            if (result == null || result.Count == 0) { 
            return NotFound("Hasta Geçmişi bulunamadı");
            }
            return Ok(result);
        }
    }
}
