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
    public class ComentarioControler : ControllerBase
    {
        private readonly IComentarioService _ComentarioService;
                                                                                                                                                                                                                                                                                                                                                                
        public ComentarioControler(IComentarioService ComentarioService)
        {
            this._ComentarioService = ComentarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comentario>>> Get()
        {
            return await _ComentarioService.GetComentarios();

        }

        [HttpGet("{id:int}", Name = "GetComentario")]
        public async Task<ActionResult<Comentario>> Get(int id)
        {
            var entity = await _ComentarioService.GetComentario(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Comentario>> Post(Comentario Comentario)
        {
            await _ComentarioService.CreateComentario(Comentario);
            return CreatedAtRoute("GetComentario", new { id = Comentario.Id }, Comentario);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Comentario Comentario)
        {

            if (id != Comentario.Id) return BadRequest();

            await _ComentarioService.UpdateComentario(Comentario);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Comentario = await _ComentarioService.GetComentario(id);
            if (Comentario == null)
            {
                return NotFound();
            }
            else
            {
                await _ComentarioService.DeleteComentario(Comentario);
                return NoContent();
            }
        }
    }
}
