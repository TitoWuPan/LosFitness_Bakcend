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
    public class HorarioControler : ControllerBase
    {
        private readonly IHorarioService _HorarioService;
                                                                                                                                                                                                                                                                                                                                                                
        public HorarioControler(IHorarioService HorarioService)
        {
            this._HorarioService = HorarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horario>>> Get()
        {
            return await _HorarioService.GetHorarios();

        }

        [HttpGet("{id:int}", Name = "GetHorario")]
        public async Task<ActionResult<Horario>> Get(int id)
        {
            var entity = await _HorarioService.GetHorario(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Horario>> Post(Horario Horario)
        {
            await _HorarioService.CreateHorario(Horario);
            return CreatedAtRoute("GetHorario", new { id = Horario.Id }, Horario);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Horario Horario)
        {

            if (id != Horario.Id) return BadRequest();

            await _HorarioService.UpdateHorario(Horario);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Horario = await _HorarioService.GetHorario(id);
            if (Horario == null)
            {
                return NotFound();
            }
            else
            {
                await _HorarioService.DeleteHorario(Horario);
                return NoContent();
            }
        }
    }
}
