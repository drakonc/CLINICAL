using CLINICAL.Application.UseCase.UseCase.Analysis.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCase.Analysis.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCase.Analysis.Commands.DeleteCommand;
using CLINICAL.Application.UseCase.UseCase.Analysis.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCase.Analysis.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCase.Analysis.Queries.GetByIdQuery;
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

        [HttpGet("{analysisId:int}")]
        public async Task<IActionResult> AnalysisById(int analysisId)
        {
            var respuesta = await _medietor.Send(new GetByIdAnalysisQuery() { AnalysisId = analysisId });
            return Ok(respuesta);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAnalysis([FromBody] CreateAnalysisCommand command)
        {
            var respuesta = await _medietor.Send(command);
            return Ok(respuesta);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditAnalysis([FromBody] UpdateAnalysisCommand command)
        {
            var respuesta = await _medietor.Send(command);
            return Ok(respuesta);
        }

        [HttpDelete("Remove/{analysisId:int}")]
        public async Task<IActionResult> DeleteAnalysis(int analysisId)
        {
            var respuesta = await _medietor.Send(new DeleteAnalysisCommand() { AnalysisId = analysisId });
            return Ok(respuesta);
        }

        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeState([FromBody] ChangeStateAnalysisCommand command)
        {
            var respuesta = await _medietor.Send(command);
            return Ok(respuesta);
        }
    }
}
