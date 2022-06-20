using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LosFitness.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class Usuario_RecompensaControler : ControllerBase
    {
        private readonly LosFitnessDbContext _context;

        public Usuario_RecompensaControler(LosFitnessDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Recompesa_Usuario>>> Get()
        {
            ICollection<Recompesa_Usuario> response;

            response = await _context.Recompesa_Usuarios.ToListAsync();
            
            return Ok(response);
        }

        [HttpPost("reward/{id:int}")]
        public async Task<ActionResult> Post(int id,Dto.Request.DtoRecompensas_Usuario request)
        {
            var entity = new Recompesa_Usuario
            {
                UsuarioId = id,
                RecompensaId = request.RecompensaId,
                Status = true
            };

            _context.Recompesa_Usuarios.Add(entity);
            await _context.SaveChangesAsync();

            HttpContext.Response.Headers.Add("location", $"/api/Recompesa_Usuario/{entity.Id}*");

            return Ok();
        }

    }
}
