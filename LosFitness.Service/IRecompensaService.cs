using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface IRecompensaService
    {
        Task<Recompensa> CreateRecompensa(Recompensa Recompensa);

        Task DeleteRecompensa(Recompensa Recompensa);

        Task<Recompensa> GetRecompensa(int id);

        Task<List<Recompensa>> GetRecompensas();

        Task UpdateRecompensa(Recompensa Recompensa);
    }
}
