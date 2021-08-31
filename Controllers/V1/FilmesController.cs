using catalogo_api.InputModel;
using catalogo_api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_api.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        //get all objects
        [HttpGet]
        public async Task<ActionResult<List<FilmeViewModel>>> Get()
        {
            return Ok();
        }
        //get an object
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FilmeViewModel>> Get(Guid id)
        {
            return Ok();
        }
        //new object
        [HttpPost]
        public async Task<ActionResult<FilmeViewModel>> Post(FilmeInputModel filme)
        {
            return Ok();
        }
        //update all atributtes
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, FilmeInputModel filme)
        {
            return Ok();
        }
        //update an attribute
        [HttpPatch("{id:guid}/price/{price:double}")]
        public async Task<ActionResult> Patch(Guid id, double valor)
        {
            return Ok();
        }
        //delete an object
        [HttpDelete("{id:guid}")]
        public async Task<AcceptedResult> Delete(Guid id)
        {
            return Ok();
        }
    }
}
