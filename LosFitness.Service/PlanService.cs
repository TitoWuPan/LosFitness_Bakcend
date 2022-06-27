using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.EntityFrameworkCore;

namespace LosFitness.Service
{
    public class PlanService:IPlanService
    {
        private readonly LosFitnessDbContext _context;

        public PlanService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Plan> CreatePlan(Plan Plan)
        {
            await _context.Plans.AddAsync(Plan);
            await _context.SaveChangesAsync();

            return Plan;
        }

        public async Task DeletePlan(Plan Plan)
        {
            _context.Plans.Remove(Plan);
            await _context.SaveChangesAsync();
        }

        public async Task<Plan> GetPlan(int id)
        {
            return await _context.Plans.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Plan>> GetPlans()
        {
            return await _context.Plans.ToListAsync();
        }

        public async Task UpdatePlan(Plan Plan)
        {
            _context.Entry(Plan).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
