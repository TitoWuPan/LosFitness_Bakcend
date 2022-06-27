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
    public class AlimentoService:IAlimentoService
    {
        private readonly LosFitnessDbContext _context;

        public AlimentoService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Alimento> CreateAlimento(Alimento Alimento)
        {
            await _context.Alimentos.AddAsync(Alimento);
            await _context.SaveChangesAsync();

            return Alimento;
        }

        public async Task DeleteAlimento(Alimento Alimento)
        {
            _context.Alimentos.Remove(Alimento);
            await _context.SaveChangesAsync();
        }

        public async Task<Alimento> GetAlimento(int id)
        {
            return await _context.Alimentos.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Alimento>> GetAlimentos()
        {
            return await _context.Alimentos.ToListAsync();
        }

        public async Task UpdateAlimento(Alimento Alimento)
        {
            _context.Entry(Alimento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
