using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface IHorario_ObjetivoService
    {
        Task<Horario_Objetivo> CreateHorario_Objetivo(Horario_Objetivo Horario_Objetivo);

        Task DeleteHorario_Objetivo(Horario_Objetivo Horario_Objetivo);

        Task<Horario_Objetivo> GetHorario_Objetivo(int id);

        Task<List<Horario_Objetivo>> GetHorario_Objetivos();

        Task UpdateHorario_Objetivo(Horario_Objetivo Horario_Objetivo);
    }
}
