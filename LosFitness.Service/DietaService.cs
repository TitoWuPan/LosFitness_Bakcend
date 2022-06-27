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
    public class DietaService:IDietaService
    {
        private readonly LosFitnessDbContext _context;

        public DietaService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Dieta> CreateDieta(Dieta Dieta)
        {
            await _context.Dietas.AddAsync(Dieta);
            await _context.SaveChangesAsync();

            return Dieta;
        }

        public async Task DeleteDieta(Dieta Dieta)
        {
            _context.Dietas.Remove(Dieta);
            await _context.SaveChangesAsync();
        }

        public async Task<Dieta> GetDieta(int id)
        {
            return await _context.Dietas.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Dieta>> GetDietas()
        {
            return await _context.Dietas.ToListAsync();
        }

        public async Task UpdateDieta(Dieta Dieta)
        {
            _context.Entry(Dieta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
