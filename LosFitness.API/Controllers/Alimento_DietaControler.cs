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
    public class Alimento_DietaControler : ControllerBase
    {
        private readonly IAlimento_DietaService _Alimento_DietaService;
                                                                                                                                                                                                                                                                                                                                                                
        public Alimento_DietaControler(IAlimento_DietaService Alimento_DietaService)
        {
            this._Alimento_DietaService = Alimento_DietaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alimento_Dieta>>> Get()
        {
            return await _Alimento_DietaService.GetAlimento_Dietas();
        }

        [HttpGet("{id:int}", Name = "GetAlimento_Dieta")]
        public async Task<ActionResult<Alimento_Dieta>> Get(int id)
        {
            var entity = await _Alimento_DietaService.GetAlimento_Dieta(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Alimento_Dieta>> Post(Alimento_Dieta Alimento_Dieta)
        {
            await _Alimento_DietaService.CreateAlimento_Dieta(Alimento_Dieta);
            return CreatedAtRoute("GetAlimento_Dieta", new { id = Alimento_Dieta.Id }, Alimento_Dieta);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Alimento_Dieta Alimento_Dieta)
        {

            if (id != Alimento_Dieta.Id) return BadRequest();

            await _Alimento_DietaService.UpdateAlimento_Dieta(Alimento_Dieta);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Alimento_Dieta = await _Alimento_DietaService.GetAlimento_Dieta(id);
            if (Alimento_Dieta == null)
            {
                return NotFound();
            }
            else
            {
                await _Alimento_DietaService.DeleteAlimento_Dieta(Alimento_Dieta);
                return NoContent();
            }
        }
    }
}
