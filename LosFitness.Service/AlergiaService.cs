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
    public class AlergiaService: IAlergiaService
    {
        private readonly LosFitnessDbContext _context;

        public AlergiaService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Alergia> CreateAlergia(Alergia alergia)
        {
            await _context.Alergias.AddAsync(alergia);
            await _context.SaveChangesAsync();

            return alergia;
        }

        public async Task DeleteAlergia(Alergia alergia)
        {
            _context.Alergias.Remove(alergia);
            await _context.SaveChangesAsync();
        }

        public async Task<Alergia> GetAlergia(int id)
        {
            return await _context.Alergias.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Alergia>> GetAlergias()
        {
            return await _context.Alergias.ToListAsync();
        }

        public async Task UpdateAlergia(Alergia alergia)
        {
            _context.Entry(alergia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
