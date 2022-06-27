using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface IUsuarioService
    {
        Task<Usuario> CreateUsuario(Usuario Usuario);

        Task DeleteUsuario(Usuario Usuario);

        Task<Usuario> GetUsuario(int id);

        Task<List<Usuario>> GetUsuarios();

        Task UpdateUsuario(Usuario Usuario);
    }
}
