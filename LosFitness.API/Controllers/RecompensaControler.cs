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
