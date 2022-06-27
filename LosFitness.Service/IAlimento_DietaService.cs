using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface IAlimento_DietaService
    {
        Task<Alimento_Dieta> CreateAlimento_Dieta(Alimento_Dieta Alimento_Dieta);

        Task DeleteAlimento_Dieta(Alimento_Dieta Alimento_Dieta);

        Task<Alimento_Dieta> GetAlimento_Dieta(int id);

        Task<List<Alimento_Dieta>> GetAlimento_Dietas();

        Task UpdateAlimento_Dieta(Alimento_Dieta Alimento_Dieta);
    }
}
