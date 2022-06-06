
using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static LosFitness.Dto.Request.BaseResponse;

namespace LosFitness.API.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]

    public class AlergiaControler:Controller
    {

        private readonly LosFitnessDbContext _context;

        public AlergiaControler(LosFitnessDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponseGeneric<ICollection<Alergia>>>> Get()
        {

            var response = new BaseResponseGeneric<ICollection<Alergia>>();

            try
            {
                response.Result = await _context.Alergias.ToListAsync();
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
        public async Task<ActionResult<Alergia>> Get(int id)
        {
            var entity = await _context.Alergias.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost("regsitro/{id:int}")]
        public async Task<ActionResult> Post(int id, Dto.Request.DtoAlergia request)
        {
            var entity = new Alergia
            {
                AlimentoId=request.AlimentoId,
                UsuarioId= id,
                Status=true
            };

            _context.Alergias.Add(entity);
            await _context.SaveChangesAsync();

            HttpContext.Response.Headers.Add("location", $"/api/usuario/{entity.Id}*");

            return Ok();
        }


        [HttpDelete("Eliminar Cuenta/{id:int}")]
        public async Task<ActionResult<Alergia>> Delete(int id)
        {
            var entity = await _context.Alergias.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el usuario");
            }
            else
            {
                _context.Alergias.Remove(entity);
                _context.SaveChanges();
                return Ok();
            }

            return Ok(entity);
        }





    }
}
