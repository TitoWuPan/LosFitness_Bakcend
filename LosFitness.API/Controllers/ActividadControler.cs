using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LosFitness.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ActividadControler : ControllerBase
    {
        private readonly LosFitnessDbContext _context;
                                                                                                                                                                                                                                                                                                                                                                
        public ActividadControler(LosFitnessDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Actividad>>> Get()
        {
            ICollection<Actividad> response;

            response = await _context.Actividads.ToListAsync();
            
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actividad>> Get(int id)
        {
            var entity = await _context.Actividads.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Dto.Request.DtoActividad request)
        {
            var entity = new Actividad
            {
                Titulo = request.Titulo,
                Describcion = request.Describcion,
                Status = true
            };

            _context.Actividads.Add(entity);
            await _context.SaveChangesAsync();

            HttpContext.Response.Headers.Add("location", $"/api/actividad/{entity.Id}*");

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Dto.Request.DtoActividad request)
        {
            var entity = await _context.Actividads.FindAsync(id);

            if (entity == null) return NotFound();

            entity.Titulo = request.Titulo;
            entity.Describcion = request.Describcion;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { Id = id });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Actividad>> Delete(int id)
        {
            var entity = await _context.Actividads.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }
            else
            {
                _context.Actividads.Remove(entity);
                _context.SaveChanges();
                return Ok();
            }

            return Ok(entity);
        }
    }
}
