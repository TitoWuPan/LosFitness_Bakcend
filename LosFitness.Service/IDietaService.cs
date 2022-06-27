using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface IDietaService
    {
        Task<Dieta> CreateDieta(Dieta Dieta);

        Task DeleteDieta(Dieta Dieta);

        Task<Dieta> GetDieta(int id);

        Task<List<Dieta>> GetDietas();

        Task UpdateDieta(Dieta Dieta);
    }
}
