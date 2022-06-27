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
    public class UsuarioControler : ControllerBase
    {
        private readonly IUsuarioService _UsuarioService;
                                                                                                                                                                                                                                                                                                                                                                
        public UsuarioControler(IUsuarioService UsuarioService)
        {
            this._UsuarioService = UsuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            return await _UsuarioService.GetUsuarios();

        }

        [HttpGet("{id:int}", Name = "GetUsuario")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var entity = await _UsuarioService.GetUsuario(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario Usuario)
        {
            await _UsuarioService.CreateUsuario(Usuario);
            return CreatedAtRoute("GetUsuario", new { id = Usuario.Id }, Usuario);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Usuario Usuario)
        {

            if (id != Usuario.Id) return BadRequest();

            await _UsuarioService.UpdateUsuario(Usuario);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Usuario = await _UsuarioService.GetUsuario(id);
            if (Usuario == null)
            {
                return NotFound();
            }
            else
            {
                await _UsuarioService.DeleteUsuario(Usuario);
                return NoContent();
            }
        }
    }
}
