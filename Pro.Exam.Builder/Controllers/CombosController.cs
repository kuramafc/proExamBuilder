using Microsoft.AspNetCore.Mvc;
using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class CombosController : ControllerBase
    {
        private readonly ICombosService _combosService;

        public CombosController(ICombosService combosService)
        {
            _combosService = combosService;
        }

        // GET api/v1/Combo/Subjects
        /// <summary>
        /// Returns a list of 'Disciplinas'.
        /// </summary>
        [HttpGet("Subjects")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetSubjects(int matterId)
        {
            var result = await _combosService.GetSubjects(matterId);

            return Ok(result);
        }

        // POST api/v1/Combo/Subjects
        /// <summary>
        /// Register a list of questions.
        /// </summary>
        /// <param name="questions"></param>
        /// <response code="201">Registered with success</response>
        /// <response code="400">Bad request</response> 
        [HttpPost("Subjects")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<StatusCodeResult> PostSubjects(string subject, int matterId)
        {
            if (subject == null)
            {
                return BadRequest();
            }

            var result = await _combosService.PostSubject(subject, matterId);

            if (result)
            {
                return StatusCode(201);
            }

            return StatusCode(500);
        }

        // DELETE api/v1/Combo/Subjects
        /// <summary>
        /// Delete a 'Disciplica'.
        /// </summary>
        [HttpDelete("Subjects")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> DeleteSubjects(int subjectId, int matterId)
        {
            if (matterId == 0 || subjectId == 0)
            {
                return BadRequest();
            }

            var result = await _combosService.DeleteSubject(subjectId, matterId);

            if (result)
            {
                return Ok(subjectId + " Was deleted");
            }
            return StatusCode(500);
        }

        // GET api/v1/Combo/Matters
        /// <summary>
        /// Returns a list of 'Matérias'.
        /// </summary>
        [HttpGet("Matters")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<MatterDto>>> GetMatters()
        {
            var result = await _combosService.GetMatters();

            return Ok(result);
        }

        // POST api/v1/Combo/Matters
        /// <summary>
        /// Create a 'Matérias'.
        /// </summary>
        [HttpPost("Matters")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<StatusCodeResult> PostMatters(string matter)
        {
            if (matter == null)
            {
                return BadRequest();
            }

            var result = await _combosService.PostMatter(matter);

            if (result)
            {
                return StatusCode(201);
            }

            return StatusCode(500);
        }

        // DELETE api/v1/Combo/Matters
        /// <summary>
        /// Delete a 'Matéria'.
        /// </summary>
        [HttpDelete("Matters")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> DeleteMatters(int matterId)
        {
            if (matterId == 0)
            {
                return BadRequest();
            }

            var result = await _combosService.DeleteMatter(matterId);

            if (result)
            {
                return Ok(matterId + " Was deleted");
            }
            return StatusCode(500);
        }
    }
}
