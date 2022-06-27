using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface IHorarioService
    {
        Task<Horario> CreateHorario(Horario Horario);

        Task DeleteHorario(Horario Horario);

        Task<Horario> GetHorario(int id);

        Task<List<Horario>> GetHorarios();

        Task UpdateHorario(Horario Horario);
    }
}
