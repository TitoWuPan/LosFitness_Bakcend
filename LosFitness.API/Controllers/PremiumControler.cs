using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static LosFitness.Dto.Request.BaseResponse;

namespace LosFitness.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PremiumControler : ControllerBase
    {
        private readonly LosFitnessDbContext _context;
                                                                                                                                                                                                                                                                                                                                                                
        public PremiumControler(LosFitnessDbContext context)
        {
            _context = context;
        }

        [HttpPut("dar/{id:int}")]
        public async Task<ActionResult> PutTrue(int id, Dto.Request.DtoUsuario request)
        {
            var entity = await _context.Usuarios.FindAsync(id);

            if (entity == null) return NotFound();

            entity.Premiun = true;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { Id = id });
        }

        [HttpPut("quitar/{id:int}")]
        public async Task<ActionResult> PutFalse(int id, Dto.Request.DtoUsuario request)
        {
            var entity = await _context.Usuarios.FindAsync(id);

            if (entity == null) return NotFound();

            entity.Premiun = false;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { Id = id });
        }

    }
}
