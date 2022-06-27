using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface IObjetivoService
    {
        Task<Objetivo> CreateObjetivo(Objetivo Objetivo);

        Task DeleteObjetivo(Objetivo Objetivo);

        Task<Objetivo> GetObjetivo(int id);

        Task<List<Objetivo>> GetObjetivos();

        Task UpdateObjetivo(Objetivo Objetivo);
    }
}
