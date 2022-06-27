using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface ICatalogoService
    {
        Task<Catalogo> CreateCatalogo(Catalogo Catalogo);

        Task DeleteCatalogo(Catalogo Catalogo);

        Task<Catalogo> GetCatalogo(int id);

        Task<List<Catalogo>> GetCatalogos();

        Task UpdateCatalogo(Catalogo Catalogo);
    }
}
