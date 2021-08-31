using catalogo_api.InputModel;
using catalogo_api.Services;
using catalogo_api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_api.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmesController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }
        //get all objects
        [HttpGet]
        public async Task<ActionResult<List<FilmeViewModel>>> Get([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, int.MaxValue)] int quantidade = 1)
        {
            var result = await _filmeService.Get(pagina, quantidade);
            if (result.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }
        //get an object
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FilmeViewModel>> Get([FromRoute] Guid id)
        {
            var filme = await _filmeService.Get(id);
            if(filme == null)
            {
                return NoContent();
            }
            return Ok();
        }
        //new object
        [HttpPost]
        public async Task<ActionResult<FilmeViewModel>> Post([FromBody] FilmeInputModel filmeInput)
        {
            try
            {
                var filme = await _filmeService.Post(filmeInput);
                return Ok(filme);
            }
            catch (Exception ex)
            {

                return UnprocessableEntity("Filme já existente");
            }
        }
        //update all atributtes
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put([FromRoute]Guid id, [FromBody]FilmeInputModel filme)
        {
            try
            {
                await _filmeService.Put(id, filme);
                return Ok();

            }
            catch (Exception ex)
            {
                return NotFound("Filme não encontrado no banco de dados");
            }
        }
        //update an attribute
        [HttpPatch("{id:guid}/price/{price:double}")]
        public async Task<ActionResult> Patch([FromRoute]Guid id,[FromRoute] double valor)
        {
            try
            {
                await _filmeService.Patch(id,valor);
                return Ok();

            }
            catch (Exception ex)
            {

                return NotFound("Filme não encontrado no banco de dados");

            }
        }
        //delete an object
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _filmeService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return NotFound("Filme não encontrado no banco de dados");
            }
        }
    }
}
