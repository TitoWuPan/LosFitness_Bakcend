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
    public class HorarioService:IHorarioService
    {
        private readonly LosFitnessDbContext _context;

        public HorarioService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Horario> CreateHorario(Horario Horario)
        {
            await _context.Horarios.AddAsync(Horario);
            await _context.SaveChangesAsync();

            return Horario;
        }

        public async Task DeleteHorario(Horario Horario)
        {
            _context.Horarios.Remove(Horario);
            await _context.SaveChangesAsync();
        }

        public async Task<Horario> GetHorario(int id)
        {
            return await _context.Horarios.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Horario>> GetHorarios()
        {
            return await _context.Horarios.ToListAsync();
        }

        public async Task UpdateHorario(Horario Horario)
        {
            _context.Entry(Horario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
