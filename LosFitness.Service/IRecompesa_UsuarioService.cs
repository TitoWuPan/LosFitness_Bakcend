using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface IRecompesa_UsuarioService
    {
        Task<Recompesa_Usuario> CreateRecompesa_Usuario(Recompesa_Usuario Recompesa_Usuario);

        Task DeleteRecompesa_Usuario(Recompesa_Usuario Recompesa_Usuario);

        Task<Recompesa_Usuario> GetRecompesa_Usuario(int id);

        Task<List<Recompesa_Usuario>> GetRecompesa_Usuarios();

        Task UpdateRecompesa_Usuario(Recompesa_Usuario Recompesa_Usuario);
    }
}
