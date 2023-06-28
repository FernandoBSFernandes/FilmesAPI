﻿using BusinessRulesContracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Request;

namespace APIProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        private readonly IRetornaFilmesBO retornaTodosFilmesBO;
        private readonly ISalvarFilmesBO salvarFilmesBO;

        public FilmeController(IRetornaFilmesBO retornaTodosFilmesBO, ISalvarFilmesBO salvarFilmesBO)
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
        public ActionResult GetOne(long id)
        {
            var response = retornaTodosFilmesBO.RetornaFilmePorId(id);
            return StatusCode((int)response.CodigoStatus, response);
        }

        [HttpPost("/incluir")]
        public ActionResult Salvar([FromBody] SalvarFilmeRequestDTO request)
        {
            var response = salvarFilmesBO.SalvarFilme(request);

            return StatusCode((int)response.CodigoStatus, response);
        }

        [HttpPut("/atualizar/{id}")]
        public void Atualizar(int id, [FromBody] string value)
        {
        }

        [HttpPatch]
        public /*ActionResult*/ void AtualizarInfoFilme(int id, [FromBody] object value)
        {

        }

        [HttpDelete("/remover/{id}")]
        public void Remover(int id)
        {
        }
    }
}
