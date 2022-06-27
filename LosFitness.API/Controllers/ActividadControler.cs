using LosFitness.DataAccess;
using LosFitness.Entities;
using LosFitness.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static LosFitness.Dto.Request.BaseResponse;

namespace LosFitness.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ActividadControler : ControllerBase
    {
        private readonly IActividadService _actividadService;
                                                                                                                                                                                                                                                                                                                                                                
        public ActividadControler(IActividadService actividadService)
        {
            this._actividadService = actividadService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividad>>> Get()
        {
            return await _actividadService.GetActividads();

        }

        [HttpGet("{id:int}", Name = "GetActividad")]
        public async Task<ActionResult<Actividad>> Get(int id)
        {
            var entity = await _actividadService.GetActividad(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Actividad>> Post(Actividad actividad)
        {
            await _actividadService.CreateActividad(actividad);
            return CreatedAtRoute("GetActividad", new { id = actividad.Id }, actividad); 
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Actividad actividad)
        {

            if (id != actividad.Id) return BadRequest();

            await _actividadService.UpdateActividad(actividad);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var actividad = await _actividadService.GetActividad(id);
            if (actividad == null)
            {
                return NotFound();
            }
            else
            {
                await _actividadService.DeleteActividad(actividad);
                return NoContent();
            }
        }
    }
}
