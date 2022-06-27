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
    public class AlergiaControler : ControllerBase
    {
        private readonly IAlergiaService _alergiaService;
                                                                                                                                                                                                                                                                                                                                                                
        public AlergiaControler(IAlergiaService AlergiaService)
        {
            this._alergiaService = AlergiaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alergia>>> Get()
        {
            return await _alergiaService.GetAlergias();

        }

        [HttpGet("{id:int}", Name = "GetAlergia")]
        public async Task<ActionResult<Alergia>> Get(int id)
        {
            var entity = await _alergiaService.GetAlergia(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Alergia>> Post(Alergia Alergia)
        {
            await _alergiaService.CreateAlergia(Alergia);
            return CreatedAtRoute("GetAlergia", new { id = Alergia.Id }, Alergia);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Alergia Alergia)
        {

            if (id != Alergia.Id) return BadRequest();

            await _alergiaService.UpdateAlergia(Alergia);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Alergia = await _alergiaService.GetAlergia(id);
            if (Alergia == null)
            {
                return NotFound();
            }
            else
            {
                await _alergiaService.DeleteAlergia(Alergia);
                return NoContent();
            }
        }
    }
}
