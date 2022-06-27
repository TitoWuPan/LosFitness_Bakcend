using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface IAlergiaService
    {
        Task<Alergia> CreateAlergia(Alergia alergia);

        Task DeleteAlergia(Alergia alergia);

        Task<Alergia> GetAlergia(int id);

        Task<List<Alergia>> GetAlergias();

        Task UpdateAlergia(Alergia alergia);
    }
}
