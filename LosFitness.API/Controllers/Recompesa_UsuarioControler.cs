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
    public class Recompesa_UsuarioControler : ControllerBase
    {
        private readonly IRecompesa_UsuarioService _Recompesa_UsuarioService;
                                                                                                                                                                                                                                                                                                                                                                
        public Recompesa_UsuarioControler(IRecompesa_UsuarioService Recompesa_UsuarioService)
        {
            this._Recompesa_UsuarioService = Recompesa_UsuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recompesa_Usuario>>> Get()
        {
            return await _Recompesa_UsuarioService.GetRecompesa_Usuarios();

        }

        [HttpGet("{id:int}", Name = "GetRecompesa_Usuario")]
        public async Task<ActionResult<Recompesa_Usuario>> Get(int id)
        {
            var entity = await _Recompesa_UsuarioService.GetRecompesa_Usuario(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Recompesa_Usuario>> Post(Recompesa_Usuario Recompesa_Usuario)
        {
            await _Recompesa_UsuarioService.CreateRecompesa_Usuario(Recompesa_Usuario);
            return CreatedAtRoute("GetRecompesa_Usuario", new { id = Recompesa_Usuario.Id }, Recompesa_Usuario);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Recompesa_Usuario Recompesa_Usuario)
        {

            if (id != Recompesa_Usuario.Id) return BadRequest();

            await _Recompesa_UsuarioService.UpdateRecompesa_Usuario(Recompesa_Usuario);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Recompesa_Usuario = await _Recompesa_UsuarioService.GetRecompesa_Usuario(id);
            if (Recompesa_Usuario == null)
            {
                return NotFound();
            }
            else
            {
                await _Recompesa_UsuarioService.DeleteRecompesa_Usuario(Recompesa_Usuario);
                return NoContent();
            }
        }
    }
}
