using Microsoft.AspNetCore.Mvc;
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
        // GET api/v1/Combo/Subjects
        /// <summary>
        /// Returns a list of 'Disciplinas'.
        /// </summary>
        [HttpGet("Subjects")]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<string>> getSubjects()
        {
            return new string[] { "Sistemas de informação", "Fisica"};
        }

        // GET api/v1/Combo/Matter
        /// <summary>
        /// Returns a list of 'Matérias'.
        /// </summary>
        [HttpGet("Matter")]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<string>> GetMatters()
        {
            return new string[] { "Dps distribuidas", "Calculo 8 grau" };
        }
    }
}
