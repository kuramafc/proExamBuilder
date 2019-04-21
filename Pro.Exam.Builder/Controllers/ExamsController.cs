using Microsoft.AspNetCore.Mvc;
using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using Pro.Exam.Builder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void GetQuestions([FromBody] ExamDto exam)
        {

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
        public void RegisterQuestions([FromBody] QuestionsDto questions)
        {

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
        public void DeleteQuestions(int questionId)
        {

        }

        // POST api/v1/Exams/ExamGerenate
        /// <summary>
        /// Generate exam.
        /// </summary>
        /// <param name="questions"></param>
        /// <response code="201">Registered with success</response>
        /// <response code="400">Bad request</response> 
        [HttpPost("ExamGenerate")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<ExamLinks> ExamGerenate([FromBody] ExamDto exam)
        {
            return new ExamLinks() { DocX = "http://download.doc", PDF = "http://download.pdf" };
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
        public ActionResult<IEnumerable<ExamLinks>> ExamGerenate(string matter, string subject)
        {
            List<ExamLinks> examLinks = new List<ExamLinks>
            {
                new ExamLinks() { DocX = "http://download.doc", PDF = "http://download.pdf" }
            };

            return examLinks;
        }
    }
}
