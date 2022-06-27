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
    public class Horario_ObjetivoControler : ControllerBase
    {
        private readonly IHorario_ObjetivoService _Horario_ObjetivoService;

        public Horario_ObjetivoControler(IHorario_ObjetivoService Horario_ObjetivoService)
        {
            this._Horario_ObjetivoService = Horario_ObjetivoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horario_Objetivo>>> Get()
        {
            return await _Horario_ObjetivoService.GetHorario_Objetivos();
        }

        [HttpGet("{id:int}", Name = "GetHorario_Objetivo")]
        public async Task<ActionResult<Horario_Objetivo>> Get(int id)
        {
            var entity = await _Horario_ObjetivoService.GetHorario_Objetivo(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Horario_Objetivo>> Post(Horario_Objetivo Horario_Objetivo)
        {
            await _Horario_ObjetivoService.CreateHorario_Objetivo(Horario_Objetivo);
            return CreatedAtRoute("GetHorario_Objetivo", new { id = Horario_Objetivo.Id }, Horario_Objetivo);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Horario_Objetivo Horario_Objetivo)
        {

            if (id != Horario_Objetivo.Id) return BadRequest();

            await _Horario_ObjetivoService.UpdateHorario_Objetivo(Horario_Objetivo);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Horario_Objetivo = await _Horario_ObjetivoService.GetHorario_Objetivo(id);
            if (Horario_Objetivo == null)
            {
                return NotFound();
            }
            else
            {
                await _Horario_ObjetivoService.DeleteHorario_Objetivo(Horario_Objetivo);
                return NoContent();
            }
        }
    }
}
