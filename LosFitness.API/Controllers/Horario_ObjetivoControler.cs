using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LosFitness.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class Horario_ObjetivoControler : ControllerBase
    {
        private readonly LosFitnessDbContext _context;

        public Horario_ObjetivoControler(LosFitnessDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Horario_Objetivo>>> Get()
        {
            ICollection<Horario_Objetivo> response;

            response = await _context.Horario_Objetivos.ToListAsync();
            
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Horario_Objetivo>> Get(int id)
        {
            var entity = await _context.Horario_Objetivos.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el objetivo");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Dto.Request.DtoHorario_Objetivo request)
        {
            var entity = new Horario_Objetivo
            {
                HorarioId = request.HorarioId,
                ObjetivoId = request.ObjetivoId,
                Check = false,
                Fecha = request.Fecha,
                Status = true
            };

            _context.Horario_Objetivos.Add(entity);
            await _context.SaveChangesAsync();

            HttpContext.Response.Headers.Add("location", $"/api/horario_objetivo/{entity.Id}*");

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Dto.Request.DtoHorario_Objetivo request)
        {
            var entity = await _context.Horario_Objetivos.FindAsync(id);

            if (entity == null) return NotFound();

            entity.HorarioId = request.HorarioId;
            entity.ObjetivoId = request.ObjetivoId;
            entity.Fecha = request.Fecha;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { Id = id });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Horario_Objetivo>> Delete(int id)
        {
            var entity = await _context.Horario_Objetivos.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }
            else
            {
                _context.Horario_Objetivos.Remove(entity);
                _context.SaveChanges();
                return Ok();
            }
            
            return Ok(entity);
        }
    }
}
