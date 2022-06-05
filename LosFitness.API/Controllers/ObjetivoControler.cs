using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LosFitness.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ObjetivoControler : ControllerBase
    {
        private readonly LosFitnessDbContext _context;

        public ObjetivoControler(LosFitnessDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Objetivo>>> Get()
        {
            ICollection<Objetivo> response;

            response = await _context.Objetivos.ToListAsync();
            
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Objetivo>> Get(int id)
        {
            var entity = await _context.Objetivos.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el objetivo");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Dto.Request.DtoObjetivo request)
        {
            var entity = new Objetivo
            {
                Titulo = request.Titulo,
                Describcion = request.Describcion,
                Status = true
            };

            _context.Objetivos.Add(entity);
            await _context.SaveChangesAsync();

            HttpContext.Response.Headers.Add("location", $"/api/objetivo/{entity.Id}*");

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Dto.Request.DtoObjetivo request)
        {
            var entity = await _context.Objetivos.FindAsync(id);

            if (entity == null) return NotFound();

            entity.Titulo = request.Titulo;
            entity.Describcion = request.Describcion;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { Id = id });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Objetivo>> Delete(int id)
        {
            var entity = await _context.Objetivos.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }
            else
            {
                _context.Objetivos.Remove(entity);
                _context.SaveChanges();
                return Ok();
            }
            
            return Ok(entity);
        }
    }
}
