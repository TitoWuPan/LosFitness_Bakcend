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
    public class Horario_ActividadControler : ControllerBase
    {
        private readonly IHorario_ActividadService _Horario_ActividadService;
                                                                                                                                                                                                                                                                                                                                                                
        public Horario_ActividadControler(IHorario_ActividadService Horario_ActividadService)
        {
            this._Horario_ActividadService = Horario_ActividadService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horario_Actividad>>> Get()
        {
            return await _Horario_ActividadService.GetHorario_Actividads();

        }

        [HttpGet("{id:int}", Name = "GetHorario_Actividad")]
        public async Task<ActionResult<Horario_Actividad>> Get(int id)
        {
            var entity = await _Horario_ActividadService.GetHorario_Actividad(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Horario_Actividad>> Post(Horario_Actividad Horario_Actividad)
        {
            await _Horario_ActividadService.CreateHorario_Actividad(Horario_Actividad);
            return CreatedAtRoute("GetHorario_Actividad", new { id = Horario_Actividad.Id }, Horario_Actividad);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Horario_Actividad Horario_Actividad)
        {

            if (id != Horario_Actividad.Id) return BadRequest();

            await _Horario_ActividadService.UpdateHorario_Actividad(Horario_Actividad);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Horario_Actividad = await _Horario_ActividadService.GetHorario_Actividad(id);
            if (Horario_Actividad == null)
            {
                return NotFound();
            }
            else
            {
                await _Horario_ActividadService.DeleteHorario_Actividad(Horario_Actividad);
                return NoContent();
            }
        }
    }
}
