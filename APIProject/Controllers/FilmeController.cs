using BusinessRulesContracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Request;

namespace APIProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
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

        /// <summary>
        /// Retorna todos os filmes disponíveis.
        /// </summary>
        /// <returns>Retorna todos os filmes que tem na base.</returns>
        /// <response code="200">Retorna com sucesso quais filmes já foram disponibiizados.</response>
        [HttpGet("/obtertodos")]
        public ActionResult GetAll()
        {
            var response = retornaFilmesBO.RetornaTodosFilmes();
            return StatusCode((int)response.CodigoStatus, response);
        }

        /// <summary>
        /// Obtém um filme pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do filme desejado.</param>
        /// <response code="200">Indica que o filme foi encontrado e retornado.</response>
        /// <response code="404">Indica que o filme não foi encontrado.</response>
        /// <response code="500">Indica que houve um problema interno no servidor.</response>
        [HttpGet("/obter/{id}")]
        public ActionResult GetOne([FromRoute] long id)
        {
            var response = retornaFilmesBO.RetornaFilmePorId(id);
            return StatusCode((int)response.CodigoStatus, response);
        }

        /// <summary>
        /// Persiste um único filme na base.
        /// </summary>
        /// <returns>ID e o nome do filme que foi informado no request.</returns>
        /// <param name="request">Dados do filme que deve ser salvo, incluindo atores e diretores.</param>
        /// <response code="201">Indica que o filme foi persistido na base com sucesso. Será retornado seu ID e o nome que foi informado.</response>
        /// <response code="400">Indica que o filme possui dados não preenchidos ou preenchidos de forma incorreta.</response>
        /// <response code="500">Indica que houve um problema interno no servidor.</response>
        [HttpPost("/incluir")]
        public ActionResult Salvar([FromBody] SalvarFilmeRequestDTO request)
        {
            var response = salvarFilmesBO.SalvarFilme(request);
            return StatusCode((int)response.CodigoStatus, response);
        }


        /// <summary>
        /// Permite a persistência de uma lista de filmes.
        /// </summary>
        /// <returns>Uma lista com os nomes dos filmes salvos e seus respectivos IDs.</returns>
        /// <param name="request">Uma lista com os filmes que devem ser salvos.</param>
        /// <response code="201">Indica que os filme foram persistidos na base com sucesso. Retornará uma lista com os nomes dos filmes salvos e seus respectivos IDs.</response>
        /// <response code="400">Indica que algum possui dados não preenchidos ou preenchidos de forma incorreta.</response>
        /// <response code="500">Indica que houve um problema interno no servidor.</response>
        [HttpPost("/incluirTodos")]
        public async Task<ActionResult> SalvarFilmes([FromBody] SalvarFilmesEmLoteRequestDTO request)
        {
            var response = await salvarFilmesBO.SalvarFilmesEmLoteAsync(request);
            return StatusCode((int)response.CodigoStatus, response);
        }

        /// <summary>
        /// Atualiza um filme por completo.
        /// </summary>
        /// <param name="id">O ID do filme que deve ser atualizado.</param>
        /// <param name="request"></param>
        /// <returns>Codigo de retorno indicando o que ocorreu.</returns>
        /// <response code="204">Indica que o filme foi atualizado na base com sucesso.</response>
        /// <response code="404">Indica que o filme com o ID informado não foi encontrado.</response>
        /// <response code="500">Indica que houve um problema interno no servidor.</response>
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

        /// <summary>
        /// Remove um filme da base.
        /// </summary>
        /// <param name="id">O ID do filme que deve ser removido.</param>
        /// <returns>Codigo de Status <see cref="System.Net.HttpStatusCode">(HttpStatusCode)</see></returns>
        /// <response code="204">Indica que o filme foi removido na base com sucesso.</response>
        /// <response code="404">Indica que o filme com o ID informado não foi encontrado.</response>
        /// <response code="500">Indica que houve um problema interno no servidor.</response>
        [HttpDelete("/remover/{id}")]
        public ActionResult Remover([FromRoute] long id)
        {
            var response = removerFilmesBO.ExcluirFilme(id);
            return StatusCode((int)response.CodigoStatus, response);
        }
    }
}
