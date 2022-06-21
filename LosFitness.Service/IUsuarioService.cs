using LosFitness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosFitness.Service
{
    public interface IUsuarioService
    {
        Task<Usuario> CreateGenre(Usuario genre);
        Task DeleteGenre(Usuario genre);
        Task<Usuario> GetGenre(int id);
        Task<List<Usuario>> GetGenres();

        Task UpdateGenre(Usuario genre);
    }
}
