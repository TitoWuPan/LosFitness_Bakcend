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
    public class Horario_ObjetivoService:IHorario_ObjetivoService
    {
        private readonly LosFitnessDbContext _context;

        public Horario_ObjetivoService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Horario_Objetivo> CreateHorario_Objetivo(Horario_Objetivo Horario_Objetivo)
        {
            await _context.Horario_Objetivos.AddAsync(Horario_Objetivo);
            await _context.SaveChangesAsync();

            return Horario_Objetivo;
        }

        public async Task DeleteHorario_Objetivo(Horario_Objetivo Horario_Objetivo)
        {
            _context.Horario_Objetivos.Remove(Horario_Objetivo);
            await _context.SaveChangesAsync();
        }

        public async Task<Horario_Objetivo> GetHorario_Objetivo(int id)
        {
            return await _context.Horario_Objetivos.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Horario_Objetivo>> GetHorario_Objetivos()
        {
            return await _context.Horario_Objetivos.ToListAsync();
        }

        public async Task UpdateHorario_Objetivo(Horario_Objetivo Horario_Objetivo)
        {
            _context.Entry(Horario_Objetivo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
