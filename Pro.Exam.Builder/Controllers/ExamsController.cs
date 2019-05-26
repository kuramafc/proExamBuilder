using Microsoft.AspNetCore.Mvc;
using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces.Documents;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using Pro.Exam.Builder.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class ExamsController : ControllerBase
    {
        private readonly IExamsService _examsService;

        public ExamsController(IExamsService examsService)
        {
            _examsService = examsService;
        }

        // GET api/v1/Exams/Questions
        /// <summary>
        /// Get a list of questions.
        /// </summary>
        /// <param name="questions"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response> 
        [HttpGet("Questions")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<QuestionsDto>> GetQuestions(string userEmail)
        {
            if (userEmail == null)
            {
                return BadRequest();
            }

            var result = await _examsService.GetQuestions(userEmail);

            if (result != null)
            {
                return Ok(result);
            }

            return StatusCode(500);
        }

        // POST api/v1/Exams/Questions
        /// <summary>
        /// Register a list of questions.
        /// </summary>
        /// <param name="questions"></param>
        /// <response code="201">Registered with success</response>
        /// <response code="400">Bad request</response> 
        [HttpPost("Questions")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<StatusCodeResult> RegisterQuestions([FromBody] Question question)
        {
            if (question == null)
            {
                return BadRequest();
            }

            var result = await _examsService.RegisterQuestion(question);

            if (result)
            {
                return StatusCode(201);
            }

            return StatusCode(500);
        }

        // DELETE api/v1/Exams/Questions
        /// <summary>
        /// Delete a question.
        /// </summary>
        /// <param name="questions"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response> 
        [HttpDelete("Questions")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteQuestions(long questionCode)
        {
            if (questionCode == 0)
            {
                return BadRequest();
            }

            var result = await _examsService.DeleteQuestion(questionCode);

            if (result)
            {
                return Ok(questionCode + " Was deleted");
            }
            return StatusCode(500);
        }

        // POST api/v1/Exams/ExamGerenatePreview
        /// <summary>
        /// Generate exam.
        /// </summary>
        /// <param name="questions"></param>
        /// <response code="201">Registered with success</response>
        /// <response code="400">Bad request</response> 
        [HttpPost("ExamGerenatePreview")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<QuestionsDto>> ExamGerenatePreview([FromBody] ExamDto exam)
        {
            var result = await _examsService.ExamGerenatePreview(exam);

            if (result != null)
            {
                return Ok(result);
            }

            return StatusCode(500);
        }

        // POST api/v1/Exams/ExamGerenate
        /// <summary>
        /// Generate exam.
        /// </summary>
        /// <param name="questions"></param>
        /// <response code="201">Registered with success</response>
        /// <response code="400">Bad request</response> 
        [HttpPost("ExamGenerate")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ExamLinks>> ExamGerenate([FromBody] QuestionsDto question)
        {
            var result = await _examsService.ExamGerenate(question);

            if (result != null)
            {
                return Ok(result);
            }

            return StatusCode(500);
        }

        // GET api/v1/Exams/Historic
        /// <summary>
        /// Generate exam.
        /// </summary>
        /// <param name="questions"></param>
        /// <response code="201">Registered with success</response>
        /// <response code="400">Bad request</response> 
        [HttpPost("Historic")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<ExamLinks>>> Historic(long userCode = 0)
        {
            var result = await _examsService.Historic(userCode);

            if (result != null)
            {
                return Ok(result);
            }

            return StatusCode(500);
        }
    }
}
