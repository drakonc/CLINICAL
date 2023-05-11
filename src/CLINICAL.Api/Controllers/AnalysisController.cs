using MediatR;
using Microsoft.AspNetCore.Mvc;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Application.UseCase.UseCase.Analysis.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCase.Analysis.Queries.GetByIdQuery;
using CLINICAL.Application.UseCase.UseCase.Analysis.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCase.Analysis.Commands.DeleteCommand;
using CLINICAL.Application.UseCase.UseCase.Analysis.Commands.UpdateCommand;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _medietor;
        private readonly CreateAnalysisValidator _createValidate;
        private readonly UpdateAnalysisValidator _updateValidate;

        public AnalysisController(IMediator medietor, CreateAnalysisValidator createValidate, UpdateAnalysisValidator updateValidate)
        {
            _medietor = medietor;
            _createValidate = createValidate;
            _updateValidate = updateValidate;
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
            var validar = await _createValidate.ValidateAsync(command);
            var respuesta = new BaseResponse<bool>();
            if (!validar.IsValid)
            {
                List<BaseError> errors = new List<BaseError>();
                validar.Errors.ForEach(x => errors.Add(new BaseError() { PropertyName = x.PropertyName, ErrorMessage = x.ErrorMessage }));
                respuesta.Erros = errors;
                respuesta.IsSuccess = false;
                respuesta.Message = "Error de validaciones";
                return Ok(respuesta);
            }
            respuesta = await _medietor.Send(command);
            return Ok(respuesta);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditAnalysis([FromBody] UpdateAnalysisCommand command)
        {
            var validar = await _updateValidate.ValidateAsync(command);
            var respuesta = new BaseResponse<bool>();
            if (!validar.IsValid)
            {
                List<BaseError> errors = new List<BaseError>();
                validar.Errors.ForEach(x => errors.Add(new BaseError() { PropertyName = x.PropertyName, ErrorMessage = x.ErrorMessage }));
                respuesta.Erros = errors;
                respuesta.IsSuccess = false;
                respuesta.Message = "Error de validaciones";
                return Ok(respuesta);
            }
            respuesta = await _medietor.Send(command);
            return Ok(respuesta);
        }

        [HttpDelete("Remove/{analysisId:int}")]
        public async Task<IActionResult> DeleteAnalysis(int analysisId)
        {
            var respuesta = await _medietor.Send(new DeleteAnalysisCommand() { AnalysisId = analysisId });
            return Ok(respuesta);
        }
    }
}
