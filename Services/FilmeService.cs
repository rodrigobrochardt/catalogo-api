using catalogo_api.Entities;
using catalogo_api.InputModel;
using catalogo_api.Repositories;
using catalogo_api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_api.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task Delete(Guid id)
        {
            var filme = await _filmeRepository.Get(id);
            if (filme == null)
            {
                throw new ArgumentNullException();
            }
            await _filmeRepository.Delete(id);
        }

        public void Dispose()
        {
            _filmeRepository?.Dispose();
        }

        public async Task<List<FilmeViewModel>> Get(int pagina, int quantidade)
        {
            var filmes = await _filmeRepository.Get(pagina, quantidade);

            return filmes.Select(filme => new FilmeViewModel
            {
                Id = filme.Id,
                Diretor = filme.Diretor,
                Titulo = filme.Titulo,
                Valor = filme.Valor
            }).ToList();
        }

        public async Task<FilmeViewModel> Get(Guid id)
        {
            var filme = await _filmeRepository.Get(id);
            if (filme == null)
            {
                return null;
            }
            return new FilmeViewModel
            {
                Id = filme.Id,
                Diretor = filme.Diretor,
                Titulo = filme.Titulo,
                Valor = filme.Valor
            };
        }

        public async Task Patch(Guid id, double valor)
        {
            var filme = await _filmeRepository.Get(id);

            if (filme == null)
            {
                throw new ArgumentNullException();
            }
            await _filmeRepository.Patch(id, valor);
        }

        public async Task<FilmeViewModel> Post(FilmeInputModel filme)
        {
            var entityFilme = await _filmeRepository.Get(filme.Diretor, filme.Titulo);

            if (entityFilme == null)
            {
                throw new ArgumentNullException();
            }
            var newFilme = new Filme
            {
                Id = Guid.NewGuid(),
                Diretor = filme.Diretor,
                Titulo = filme.Titulo,
                Valor = filme.Valor
            };
            await _filmeRepository.Post(newFilme);
            return new FilmeViewModel
            {
                Id = newFilme.Id,
                Diretor = newFilme.Diretor,
                Titulo = newFilme.Titulo,
                Valor = newFilme.Valor
            };
        }

        public async Task Put(Guid id, FilmeInputModel filme)
        {
            var entityFilme = await _filmeRepository.Get(id);
            if (entityFilme == null)
            {
                throw new ArgumentNullException();
            }
            entityFilme.Titulo = filme.Titulo;
            entityFilme.Valor = filme.Valor;
            entityFilme.Diretor = filme.Diretor;

            await _filmeRepository.Put(id, entityFilme);

        }
    }
}
