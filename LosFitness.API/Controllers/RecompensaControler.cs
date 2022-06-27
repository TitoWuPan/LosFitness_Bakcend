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
    public class RecompensaControler : ControllerBase
    {
        private readonly IRecompensaService _RecompensaService;
                                                                                                                                                                                                                                                                                                                                                                
        public RecompensaControler(IRecompensaService RecompensaService)
        {
            this._RecompensaService = RecompensaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recompensa>>> Get()
        {
            return await _RecompensaService.GetRecompensas();

        }

        [HttpGet("{id:int}", Name = "GetRecompensa")]
        public async Task<ActionResult<Recompensa>> Get(int id)
        {
            var entity = await _RecompensaService.GetRecompensa(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Recompensa>> Post(Recompensa Recompensa)
        {
            await _RecompensaService.CreateRecompensa(Recompensa);
            return CreatedAtRoute("GetRecompensa", new { id = Recompensa.Id }, Recompensa);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Recompensa Recompensa)
        {

            if (id != Recompensa.Id) return BadRequest();

            await _RecompensaService.UpdateRecompensa(Recompensa);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Recompensa = await _RecompensaService.GetRecompensa(id);
            if (Recompensa == null)
            {
                return NotFound();
            }
            else
            {
                await _RecompensaService.DeleteRecompensa(Recompensa);
                return NoContent();
            }
        }
    }
}
