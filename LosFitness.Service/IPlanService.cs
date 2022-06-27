using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface IPlanService
    {
        Task<Plan> CreatePlan(Plan Plan);

        Task DeletePlan(Plan Plan);

        Task<Plan> GetPlan(int id);

        Task<List<Plan>> GetPlans();

        Task UpdatePlan(Plan Plan);
    }
}
