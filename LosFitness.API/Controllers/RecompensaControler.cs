using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LosFitness.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RecompensaControler : ControllerBase
    {
        private readonly LosFitnessDbContext _context;

        public RecompensaControler(LosFitnessDbContext context)
        {
            _context = context;
        }
        
        [HttpPost("Recompensa")]
        public async Task<ActionResult> Post(Dto.Request.DtoRecompensas request)
        {
            var entity = new Recompensa
            {
                Titulo = request.Titulo,
                Describcion = request.Describcion,
                Status = true
            };

            _context.Recompensas.Add(entity);
            await _context.SaveChangesAsync();

            HttpContext.Response.Headers.Add("location", $"/api/usuario/{entity.Id}*");

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Recompensa>>> Get()
        {
            ICollection<Recompensa> response;

            response = await _context.Recompensas.ToListAsync();
            
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Recompensa>> Get(int id)
        {
            var entity = await _context.Recompensas.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró la recompensa");
            }

            return Ok(entity);
        }

    }
}
