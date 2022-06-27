using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface IComentarioService
    {
        Task<Comentario> CreateComentario(Comentario Comentario);

        Task DeleteComentario(Comentario Comentario);

        Task<Comentario> GetComentario(int id);

        Task<List<Comentario>> GetComentarios();

        Task UpdateComentario(Comentario Comentario);
    }
}
