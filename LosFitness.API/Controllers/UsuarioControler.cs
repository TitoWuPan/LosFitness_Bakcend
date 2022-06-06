using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static LosFitness.Dto.Request.BaseResponse;

namespace LosFitness.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioControler : ControllerBase
    {
        private readonly LosFitnessDbContext _context;

        public UsuarioControler(LosFitnessDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponseGeneric<ICollection<Usuario>>>> Get()
        {
            var response = new BaseResponseGeneric<ICollection<Usuario>>();

            try
            {
                response.Result = await _context.Usuarios.ToListAsync();
                response.Success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                return response;

            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost("Registro")]
        public async Task<ActionResult> Post(Dto.Request.DtoUsuario request)
        {
            var entity = new Usuario
            {
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Genero = request.Genero,
                Premiun = false,
                ImageURL = request.ImageURL,
                Status = true
            };

            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();

            HttpContext.Response.Headers.Add("location", $"/api/usuario/{entity.Id}*");

            return Ok();
        }

        [HttpPut("Cambiar datos/{id:int}")]
        public async Task<ActionResult> PutFalse(int id, Dto.Request.DtoUsuario request)
        {
            var entity = await _context.Usuarios.FindAsync(id);

            if (entity == null) return NotFound();

            entity.Nombre = request.Nombre;
            entity.Apellido = request.Apellido;
            entity.Genero = request.Genero;
            entity.ImageURL = request.ImageURL;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { Id = id });
        }
        [HttpDelete("Eliminar Cuenta/{id:int}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el usuario");
            }
            else
            {
                _context.Usuarios.Remove(entity);
                _context.SaveChanges();
                return Ok();
            }

            return Ok(entity);
        }
    }
}