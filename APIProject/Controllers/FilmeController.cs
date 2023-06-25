using BusinessRulesContracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
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
