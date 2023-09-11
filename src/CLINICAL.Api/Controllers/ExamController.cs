﻿using CLINICAL.Application.UseCase.UseCase.Exam.Queries.GetAllQuery;
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

    }
}
