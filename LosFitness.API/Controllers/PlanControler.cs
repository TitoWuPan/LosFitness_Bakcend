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
    public class PlanControler : ControllerBase
    {
        private readonly IPlanService _PlanService;
                                                                                                                                                                                                                                                                                                                                                                
        public PlanControler(IPlanService PlanService)
        {
            this._PlanService = PlanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> Get()
        {
            return await _PlanService.GetPlans();

        }

        [HttpGet("{id:int}", Name = "GetPlan")]
        public async Task<ActionResult<Plan>> Get(int id)
        {
            var entity = await _PlanService.GetPlan(id);

            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Plan>> Post(Plan Plan)
        {
            await _PlanService.CreatePlan(Plan);
            return CreatedAtRoute("GetPlan", new { id = Plan.Id }, Plan);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Plan Plan)
        {

            if (id != Plan.Id) return BadRequest();

            await _PlanService.UpdatePlan(Plan);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Plan = await _PlanService.GetPlan(id);
            if (Plan == null)
            {
                return NotFound();
            }
            else
            {
                await _PlanService.DeletePlan(Plan);
                return NoContent();
            }
        }
    }
}
