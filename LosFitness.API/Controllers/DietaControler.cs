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
    public class DietaControler : ControllerBase
    {
        private readonly IDietaService _DietaService;
                                                                                                                                                                                                                                                                                                                                                                
        public DietaControler(IDietaService DietaService)
        {
            this._DietaService = DietaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dieta>>> Get()
        {
            return await _DietaService.GetDietas();

        }

        [HttpGet("{id:int}", Name = "GetDieta")]
        public async Task<ActionResult<Dieta>> Get(int id)
        {
            var entity = await _DietaService.GetDieta(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Dieta>> Post(Dieta dieta)
        {
            await _DietaService.CreateDieta(dieta);
            return CreatedAtRoute("GetDieta", new { id = dieta.Id }, dieta);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Dieta dieta)
        {

            if (id != dieta.Id) return BadRequest();
            await _DietaService.UpdateDieta(dieta);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var dieta = await _DietaService.GetDieta(id);
            if (dieta == null)
            {
                return NotFound();
            }
            else
            {
                await _DietaService.DeleteDieta(dieta);
                return NoContent();
            }
        }
    }
}
