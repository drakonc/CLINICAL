using CLINICAL.Application.UseCase.Patient.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.Patient.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _medietor;

        public PatientController(IMediator medietor)
        {
            _medietor = medietor;
        }

        [HttpGet("ListPatirnt")]
        public async Task<IActionResult> ListPatirnt()
        {
            var response = await _medietor.Send(new GetAllPatientQuery());
            return Ok(response);
        }

        [HttpGet("{parentId:int}")]
        public async Task<IActionResult> ParentById(int parentId)
        {
            var response = await _medietor.Send(new GetByIdPatientQuery() { PatienId = parentId });
            return Ok(response);
        }

    }
}