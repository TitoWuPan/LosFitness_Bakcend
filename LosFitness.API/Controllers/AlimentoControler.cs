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
    public class AlimentoControler : ControllerBase
    {
        private readonly IAlimentoService _AlimentoService;
                                                                                                                                                                                                                                                                                                                                                                
        public AlimentoControler(IAlimentoService AlimentoService)
        {
            this._AlimentoService = AlimentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alimento>>> Get()
        {
            return await _AlimentoService.GetAlimentos();

        }

        [HttpGet("{id:int}", Name = "GetAlimento")]
        public async Task<ActionResult<Alimento>> Get(int id)
        {
            var entity = await _AlimentoService.GetAlimento(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Alimento>> Post(Alimento Alimento)
        {
            await _AlimentoService.CreateAlimento(Alimento);
            return CreatedAtRoute("GetAlimento", new { id = Alimento.Id }, Alimento);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Alimento Alimento)
        {

            if (id != Alimento.Id) return BadRequest();

            await _AlimentoService.UpdateAlimento(Alimento);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Alimento = await _AlimentoService.GetAlimento(id);
            if (Alimento == null)
            {
                return NotFound();
            }
            else
            {
                await _AlimentoService.DeleteAlimento(Alimento);
                return NoContent();
            }
        }
    }
}
