using BusinessRulesContracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Request;

namespace APIProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        private readonly IRetornaTodosFilmesBO retornaTodosFilmesBO;
        private readonly ISalvarFilmesBO salvarFilmesBO;

        public FilmeController(IRetornaTodosFilmesBO retornaTodosFilmesBO, ISalvarFilmesBO salvarFilmesBO)
        {
            this.retornaTodosFilmesBO = retornaTodosFilmesBO;
            this.salvarFilmesBO = salvarFilmesBO;
        }

        [HttpGet("/obtertodos")]
        public ActionResult GetAll()
        {
            var response = retornaTodosFilmesBO.RetornaTodosFilmes();
            return StatusCode((int)response.CodigoStatus, response);
        }

        [HttpGet("/obter/{id}")]
        public string GetOne(int id)
        {
            return "value";
        }

        [HttpPost("/incluir")]
        public ActionResult Include([FromBody] SalvarFilmeRequestDTO request)
        {
            var response = salvarFilmesBO.SalvarFilme(request);

            return StatusCode((int)response.CodigoStatus, response);
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
