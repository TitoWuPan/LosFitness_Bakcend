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
    public class ObjetivoControler : ControllerBase
    {
        private readonly IObjetivoService _ObjetivoService;
                                                                                                                                                                                                                                                                                                                                                                
        public ObjetivoControler(IObjetivoService ObjetivoService)
        {
            this._ObjetivoService = ObjetivoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objetivo>>> Get()
        {
            return await _ObjetivoService.GetObjetivos();

        }

        [HttpGet("{id:int}", Name = "GetObjetivo")]
        public async Task<ActionResult<Objetivo>> Get(int id)
        {
            var entity = await _ObjetivoService.GetObjetivo(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Objetivo>> Post(Objetivo Objetivo)
        {
            await _ObjetivoService.CreateObjetivo(Objetivo);
            return CreatedAtRoute("GetObjetivo", new { id = Objetivo.Id }, Objetivo);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Objetivo Objetivo)
        {

            if (id != Objetivo.Id) return BadRequest();

            await _ObjetivoService.UpdateObjetivo(Objetivo);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Objetivo = await _ObjetivoService.GetObjetivo(id);
            if (Objetivo == null)
            {
                return NotFound();
            }
            else
            {
                await _ObjetivoService.DeleteObjetivo(Objetivo);
                return NoContent();
            }
        }
    }
}
