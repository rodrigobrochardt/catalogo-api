using catalogo_api.InputModel;
using catalogo_api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_api.Services
{
    public interface IFilmeService : IDisposable
    {
        Task<List<FilmeViewModel>> Get(int pagina, int quantidade);
        Task<List<FilmeViewModel>> Get(string diretor);
        Task<FilmeViewModel> Get(Guid id);
        Task<FilmeViewModel> Post(FilmeInputModel filme);
        Task Put(Guid id, FilmeInputModel filme);
        Task Patch(Guid id, decimal valor);
        Task Delete(Guid id);


    }
}
