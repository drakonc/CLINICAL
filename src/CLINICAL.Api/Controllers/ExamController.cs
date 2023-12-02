using CLINICAL.Application.UseCase.UseCase.Exam.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCase.Exam.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCase.Exam.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCase.Exam.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _medietor;

        public ExamController(IMediator medietor)
        {
            _medietor = medietor;
        }

        [HttpGet("ListExam")]
        public async Task<IActionResult> ListExam()
        {
            var response = await _medietor.Send(new GetAllExamQuery());
            return Ok(response);
        }

        [HttpGet("{examId:int}")]
        public async Task<IActionResult> ExamById(int examId)
        {
            var response = await _medietor.Send(new GetExamByIdQuery() { ExamId = examId});
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterExam([FromBody] CreateExamCommand command)
        {
            var response = await _medietor.Send(command);
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditExam([FromBody] UpdateExamCommand command)
        {
            var response = await _medietor.Send(command);
            return Ok(response);
        }

    }
}
