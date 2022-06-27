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
    public class RecompensaService: IRecompensaService
    {
        private readonly LosFitnessDbContext _context;

        public RecompensaService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Recompensa> CreateRecompensa(Recompensa Recompensa)
        {
            await _context.Recompensas.AddAsync(Recompensa);
            await _context.SaveChangesAsync();

            return Recompensa;
        }

        public async Task DeleteRecompensa(Recompensa Recompensa)
        {
            _context.Recompensas.Remove(Recompensa);
            await _context.SaveChangesAsync();
        }

        public async Task<Recompensa> GetRecompensa(int id)
        {
            return await _context.Recompensas.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Recompensa>> GetRecompensas()
        {
            return await _context.Recompensas.ToListAsync();
        }

        public async Task UpdateRecompensa(Recompensa Recompensa)
        {
            _context.Entry(Recompensa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
