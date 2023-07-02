using BusinessRulesContracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Request;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        private readonly IRetornaFilmesBO retornaFilmesBO;
        private readonly ISalvarFilmesBO salvarFilmesBO;
        private readonly IAtualizarFilmeBO atualizarFilmeBO;
        private readonly IRemoverFilmesBO removerFilmesBO;

        public FilmeController(IRetornaFilmesBO retornaFilmesBO, ISalvarFilmesBO salvarFilmesBO, IAtualizarFilmeBO atualizarFilmeBO, IRemoverFilmesBO removerFilmesBO)
        {
            this.retornaFilmesBO = retornaFilmesBO;
            this.salvarFilmesBO = salvarFilmesBO;
            this.atualizarFilmeBO = atualizarFilmeBO;
            this.removerFilmesBO = removerFilmesBO;
        }

        [HttpGet("/obtertodos")]
        public ActionResult GetAll()
        {
            var response = retornaFilmesBO.RetornaTodosFilmes();
            return StatusCode((int)response.CodigoStatus, response);
        }

        [HttpGet("/obter/{id}")]
        public ActionResult GetOne([FromRoute] long id)
        {
            var response = retornaFilmesBO.RetornaFilmePorId(id);
            return StatusCode((int)response.CodigoStatus, response);
        }

        [HttpPost("/incluir")]
        public ActionResult Salvar([FromBody] SalvarFilmeRequestDTO request)
        {
            var response = salvarFilmesBO.SalvarFilme(request);
            return StatusCode((int)response.CodigoStatus, response);
        }

        [HttpPost("/incluirTodos")]
        public ActionResult SalvarFilmes([FromBody] SalvarFilmesEmLoteRequestDTO request)
        {
            var response = salvarFilmesBO.SalvarFilmesEmLote(request);
            return StatusCode((int)response.CodigoStatus, response);
        }


        [HttpPut("/atualizar/{id}")]
        public ActionResult Atualizar([FromRoute] long id, [FromBody] AtualizarFilmeRequestDTO request)
        {
            var response = atualizarFilmeBO.AtualizarFilme(request, id);
            return StatusCode((int)response.CodigoStatus, response);
        }

        //[HttpPatch("/atualizar/{id}")]
        //public /*ActionResult*/ void AtualizarInfoFilme([FromRoute] long id, [FromBody] AtualizarFilmeRequestDTO request)
        //{

        //}

        [HttpDelete("/remover/{id}")]
        public ActionResult Remover([FromRoute] long id)
        {
            var response = removerFilmesBO.ExcluirFilme(id);
            return StatusCode((int)response.CodigoStatus, response);
        }
    }
}
