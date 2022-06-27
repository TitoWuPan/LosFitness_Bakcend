using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface IAlimentoService
    {
        Task<Alimento> CreateAlimento(Alimento Alimento);

        Task DeleteAlimento(Alimento Alimento);

        Task<Alimento> GetAlimento(int id);

        Task<List<Alimento>> GetAlimentos();

        Task UpdateAlimento(Alimento Alimento);
    }
}
