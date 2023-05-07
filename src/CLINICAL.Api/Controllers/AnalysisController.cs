using CLINICAL.Application.UseCase.UseCase.Analysis.Queries.GetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _medietor;

        public AnalysisController(IMediator medietor)
        {
            _medietor = medietor;
        }

        [HttpGet]
        public async Task<IActionResult> ListAnalysis()
        {
            var respuesta = await _medietor.Send(new GetAllAnalysisQuery());
            return Ok(respuesta);
        }
    }
}
