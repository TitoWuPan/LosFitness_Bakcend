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
    public class CatalogoControler : ControllerBase
    {
        private readonly ICatalogoService _CatalogoService;
                                                                                                                                                                                                                                                                                                                                                                
        public CatalogoControler(ICatalogoService CatalogoService)
        {
            this._CatalogoService = CatalogoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalogo>>> Get()
        {
            return await _CatalogoService.GetCatalogos();

        }

        [HttpGet("{id:int}", Name = "GetCatalogo")]
        public async Task<ActionResult<Catalogo>> Get(int id)
        {
            var entity = await _CatalogoService.GetCatalogo(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Catalogo>> Post(Catalogo Catalogo)
        {
            await _CatalogoService.CreateCatalogo(Catalogo);
            return CreatedAtRoute("GetCatalogo", new { id = Catalogo.Id }, Catalogo);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Catalogo Catalogo)
        {

            if (id != Catalogo.Id) return BadRequest();

            await _CatalogoService.UpdateCatalogo(Catalogo);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Catalogo = await _CatalogoService.GetCatalogo(id);
            if (Catalogo == null)
            {
                return NotFound();
            }
            else
            {
                await _CatalogoService.DeleteCatalogo(Catalogo);
                return NoContent();
            }
        }
    }
}
