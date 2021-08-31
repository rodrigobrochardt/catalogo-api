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
        Task<FilmeViewModel> Get(Guid id);
        Task<FilmeViewModel> Post(FilmeInputModel filme);
        Task Put(Guid id, FilmeInputModel filme);
        Task Patch(Guid id, double valor);
        Task Delete(Guid id);


    }
}
