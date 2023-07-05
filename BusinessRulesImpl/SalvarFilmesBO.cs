using AutoMapper;
using BusinessRulesContracts.Interfaces;
using Microsoft.Extensions.Configuration;
using Models.DTOs.Request;
using Models.DTOs.Response;
using Models.ErrorObject;
using Repositories.Context;
using System.Net;

using FilmesFromDTO = Models.DTOs.Objects.Filme;
using FilmesFromDB = Models.Tables.Filme;
using Models.DTOs.Objects;
using Exceptions;

namespace BusinessRulesImpl
{
    public class SalvarFilmesBO : ISalvarFilmesBO
    {

        private readonly FilmeContext context;
        private readonly IConfiguration config;
        private readonly IMapper mapper;

        public SalvarFilmesBO(FilmeContext context, IConfiguration config, IMapper mapper)
        {
            this.context = context;
            this.config = config;
            this.mapper = mapper;
        }

        public SalvarFilmeResponseDTO SalvarFilme(SalvarFilmeRequestDTO request)
        {

            try
            {
                ValidarDados(request);

                var filme = mapper.Map<FilmesFromDB>(request.DadosFilme);

                context.Filme.Add(filme);
                context.SaveChanges();
                long id = filme.Id;

                return new SalvarFilmeResponseDTO(HttpStatusCode.Created, id);

            }
            catch (Exception e)
            {
                return new SalvarFilmeResponseDTO(HttpStatusCode.BadRequest, new Erro(e.Message));
            }
        }

        private void ValidarDados(SalvarFilmeRequestDTO request)
        {
            List<Erro> erros = new List<Erro>();

            if (string.IsNullOrWhiteSpace(request.DadosFilme.Nome))
                erros.Add(new Erro("dadosFilme.nome", "Campo Obrigatório."));

            if (erros.Any())
                throw new ValidationException(erros);
        }

        public SalvarFilmesEmLoteResponseDTO SalvarFilmesEmLote(SalvarFilmesEmLoteRequestDTO request)
        {

            SalvarFilmesEmLoteResponseDTO response;

            try
            {
                var filmes = mapper.Map<List<FilmesFromDB>>(request.Filmes);

                context.Filme.AddRange(filmes);
                context.SaveChanges();

                List<DadosFilmeCriado> dadosFilmesCriado = new();

                filmes.ForEach(filme => dadosFilmesCriado.Add(new DadosFilmeCriado(filme.Nome, filme.Id)));

                response = new SalvarFilmesEmLoteResponseDTO(HttpStatusCode.Created, dadosFilmesCriado);

            }
            catch (ValidationException ex)
            {
                response = new SalvarFilmesEmLoteResponseDTO(HttpStatusCode.BadRequest, new Erro("Foram encontrados erros de validação no seu request."), ex.Erros);
            }
            catch (Exception e)
            {
                response = new SalvarFilmesEmLoteResponseDTO(HttpStatusCode.BadRequest, new Erro(e.Message));
            }

            return response;
        }
    }
}

