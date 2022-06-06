using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LosFitness.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ComentarioControler : ControllerBase
    {
        private readonly LosFitnessDbContext _context;

        public ComentarioControler(LosFitnessDbContext context)
        {
            _context = context;
        }
        //httpstatus van en categoriashttps://developer.mozilla.org/es/docs/Web/HTTP/Status 
        [HttpGet]
        public async Task<ActionResult<ICollection<Comentario>>> Get()
        {
            ICollection<Comentario> response;

            response = await _context.Comentarios.ToListAsync();

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Dto.Request.DtoComentario request)
        {
            var entity = new Comentario
            {
                UsuarioId = request.UsuarioId,
                DietaId = request.DietaId,
                Comentariotexto = request.Comentariotexto
                
                
            };

            _context.Comentarios.Add(entity);
            await _context.SaveChangesAsync();

            HttpContext.Response.Headers.Add("location", $"/api/actividad/{entity.Id}*");

            return Ok();
        }

    }
}
