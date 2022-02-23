using Insurance.Application.RiskAnalysis.Commands;
using Insurance.Domain.InputModels;
using Insurance.Domain.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class RisksController : ControllerBase
    {
        private readonly ILogger<RisksController> _logger;
        private readonly IMediator _mediator;

        public RisksController(ILogger<RisksController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Analyzes a new user insurance application
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost("analysis")]
        [ProducesResponseType(typeof(RiskAnalysisViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Analyze([FromBody] RiskAnalysisInputModel inputModel, CancellationToken cancellationToken)
        {
            var command = new RiskAnalysisCommand(inputModel);

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}