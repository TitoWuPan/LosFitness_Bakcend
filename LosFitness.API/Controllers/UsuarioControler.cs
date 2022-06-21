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
    public class UsuarioController : ControllerBase
    {
        //private readonly LosFitnessDbContext _context;

        private readonly IUsuarioService _genreService;
        /*public UsuarioController(LosFitnessDbContext context)
        {
            _context = context;
        }*/
        public UsuarioController(IUsuarioService genreService)
        {
            this._genreService = genreService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            return await _genreService.GetGenres();
        }

        [HttpGet("{id}", Name ="GetUsuario")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var genre = await _genreService.GetGenre(id);

            if(genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }
        
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario genre)
        {
            await _genreService.CreateGenre(genre);
            return CreatedAtRoute("GetUsuario", new { id = genre.Id }, genre);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genre=await _genreService.GetGenre(id);
            if(genre==null)
            {
                return NotFound();    
            }

            await _genreService.DeleteGenre(genre);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Usuario genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            await _genreService.UpdateGenre(genre);

            return NoContent();
        }
        /*[HttpGet]
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
        }*/
    }
}