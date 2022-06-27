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
    public class Alimento_DietaService:IAlimento_DietaService
    {
        private readonly LosFitnessDbContext _context;

        public Alimento_DietaService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Alimento_Dieta> CreateAlimento_Dieta(Alimento_Dieta Alimento_Dieta)
        {
            await _context.Alimento_Dietas.AddAsync(Alimento_Dieta);
            await _context.SaveChangesAsync();

            return Alimento_Dieta;
        }

        public async Task DeleteAlimento_Dieta(Alimento_Dieta Alimento_Dieta)
        {
            _context.Alimento_Dietas.Remove(Alimento_Dieta);
            await _context.SaveChangesAsync();
        }

        public async Task<Alimento_Dieta> GetAlimento_Dieta(int id)
        {
            return await _context.Alimento_Dietas.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Alimento_Dieta>> GetAlimento_Dietas()
        {
            return await _context.Alimento_Dietas.ToListAsync();
        }

        public async Task UpdateAlimento_Dieta(Alimento_Dieta Alimento_Dieta)
        {
            _context.Entry(Alimento_Dieta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
