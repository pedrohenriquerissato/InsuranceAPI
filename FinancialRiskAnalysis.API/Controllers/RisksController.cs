using Insurance.Domain.InputModels;
using Insurance.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class RisksController : ControllerBase
    {
        private readonly ILogger<RisksController> _logger;

        public RisksController(ILogger<RisksController> logger)
        {
            _logger = logger;
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
        public IActionResult Analyze([FromBody] RiskAnalysisInputModel inputModel)
        {
            var result = new RiskAnalysisViewModel();

            return Ok(result);
        }
    }
}