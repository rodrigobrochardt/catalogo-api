using catalogo_api.Entities;
using catalogo_api.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_api.Repositories
{
    public interface IFilmeRepository : IDisposable
    {
        Task<List<Filme>> Get(int pagina, int quantidade);
        Task<List<Filme>> Get(string diretor,string titulo);
        Task<Filme> Get(Guid id);
        Task Post(Filme filme);
        Task Put(Guid id, Filme filme);
        Task Patch(Guid id, double valor);
        Task Delete(Guid id);

    }
}
