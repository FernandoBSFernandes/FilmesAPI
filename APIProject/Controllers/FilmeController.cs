using BusinessRulesContracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Response;

namespace APIProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        private readonly IRetornaTodosFilmesBO retornaTodosFilmesBO;

        public FilmeController(IRetornaTodosFilmesBO retornaTodosFilmesBO)
        {
            this.retornaTodosFilmesBO = retornaTodosFilmesBO;
        }

        [HttpGet("/obtertodos")]
        public RetornaTodosFilmesResponseDTO GetAll()
        {
            return retornaTodosFilmesBO.RetornaTodosFilmes();
        }

        [HttpGet("/obter/{id}")]
        public string GetOne(int id)
        {
            return "value";
        }

        [HttpPost("/incluir")]
        public void Include([FromBody] string value)
        {
        }

        [HttpPut("/atualizar/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("/remover/{id}")]
        public void Remover(int id)
        {
        }
    }
}
