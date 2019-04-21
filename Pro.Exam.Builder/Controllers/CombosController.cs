using Microsoft.AspNetCore.Mvc;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<IEnumerable<string>> GetSubjects()
        {
            return _combosService.GetSubjects().GetAwaiter().GetResult().ToArray();
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
        public object PostSubjects(string subject)
        {
            if (subject == null)
            {
                return BadRequest();
            }

            _combosService.PostSubject(subject).GetAwaiter().GetResult();

            return Created("api/v1/Combo/Subjects", subject);
        }

        // DELETE api/v1/Combo/Subjects
        /// <summary>
        /// Delete a 'Disciplica'.
        /// </summary>
        [HttpDelete("Subjects")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public void DeleteSubjects(string subjects)
        {

        }

        // GET api/v1/Combo/Matters
        /// <summary>
        /// Returns a list of 'Matérias'.
        /// </summary>
        [HttpGet("Matters")]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<string>> GetMatters()
        {
            return _combosService.GetMatters().GetAwaiter().GetResult().ToArray();
        }

        // POST api/v1/Combo/Matters
        /// <summary>
        /// Create a 'Matérias'.
        /// </summary>
        [HttpPost("Matters")]
        [ProducesResponseType(200)]
        public object PostMatters(string matter)
        {
            if (matter == null)
            {
                return BadRequest();
            }

            return Created("api/v1/Combo/matters", matter);
        }

        // DELETE api/v1/Combo/Matters
        /// <summary>
        /// Delete a 'Matéria'.
        /// </summary>
        [HttpDelete("Matters")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public void DeleteMatters(string matter)
        {
            
        }
    }
}
