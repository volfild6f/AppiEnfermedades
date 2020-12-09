using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppiEnfermedades.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppiEnfermedades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermedadController : ControllerBase
    {
        // GET: api/Enfermedad
        [HttpGet("all")]
        public JsonResult ObtenerEnfermedad()
        {
            var enfermedadesRetornadas = EnfermedadAzure.ObtenerEnfermedades();
            return new JsonResult(enfermedadesRetornadas);
        }

        // GET: api/Enfermedad/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Enfermedad
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Enfermedad/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
