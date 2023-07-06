using AutoMapper;
using BusinessRulesContracts.Interfaces;
using Exceptions;
using Models.DTOs.Objects;
using Models.DTOs.Request;
using Models.DTOs.Response;
using Models.ErrorObject;
using Repositories.Context;
using System.Net;
using Util;

using FilmesFromDTO = Models.DTOs.Objects.Filme;
using FilmesFromDB = Models.Tables.Filme;

namespace BusinessRulesImpl
{
    public class SalvarFilmesBO : ISalvarFilmesBO
    {

        private readonly FilmeContext context;
        private readonly IMapper mapper;

        public SalvarFilmesBO(FilmeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #region Salvar apenas 1 filme por vez

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
            catch (ValidationException e)
            {
                return e.Erros == null || !e.Erros.Any()
                    ? new SalvarFilmeResponseDTO(HttpStatusCode.BadRequest, new Erro(e.Message))
                    : new SalvarFilmeResponseDTO(HttpStatusCode.BadRequest, new Erro("Ocorreram erros de validação."), e.Erros);

            }
            catch (Exception e)
            {
                return new SalvarFilmeResponseDTO(HttpStatusCode.InternalServerError, new Erro(e.Message));
            }
        }

        private void ValidarDados(SalvarFilmeRequestDTO request)
        {
            List<Erro> erros = new List<Erro>();

            if (request == null || request.DadosFilme == null)
                throw new ValidationException("Dados não informados. Favor informá-los.");

            ValidarDadosFilme(request, erros);

            if (erros.Any())
                throw new ValidationException(erros);
        }

        private void ValidarDadosFilme(SalvarFilmeRequestDTO request, List<Erro> erros)
        {
            if (string.IsNullOrWhiteSpace(request.DadosFilme.Nome))
                erros.Add(new Erro("dadosFilme.nome", "Campo Obrigatório."));

            if (!request.DadosFilme.Duracao.HasValue)
                erros.Add(new Erro("dadosFilme.duracao", "Campo Obrigatório."));

            if (!request.DadosFilme.Ano.HasValue)
                erros.Add(new Erro("dadosFilme.ano", "Campo Obrigatório."));

            ValidarDadosComplementaresFilme(request.DadosFilme, erros);
        }

        private void ValidarDadosComplementaresFilme(FilmesFromDTO dadosFilme, List<Erro> erros)
        {
            if (!dadosFilme.Atores.HasElements())
                erros.Add(new Erro("dadosFilme.atores", "Um filme precisa de 1 ou mais atores. Informe-os."));
            else
                ValidarAtoresFilme(dadosFilme.Atores, erros);

            if (!dadosFilme.Diretores.HasElements())
                erros.Add(new Erro("dadosFilme.diretores", "Um filme precisa de 1 ou mais diretores. Informe-os."));
            else
                ValidarDiretoresFilme(dadosFilme.Diretores, erros);
        }

        private void ValidarAtoresFilme(List<Ator> atores, List<Erro> erros)
        {
            var ator = atores.Where(actor => string.IsNullOrWhiteSpace(actor.Nome) || !actor.Papel.HasValue).ToList();

            for (int indice = 0; indice < ator.Count; indice++)
            {
                if (!ator[indice].Papel.HasValue)
                    erros.Add(new Erro($"dadosFilme.atores[{indice}].papel", "Informe o papel do ator ou atriz nesse índice informado."));

                if (string.IsNullOrWhiteSpace(ator[indice].Nome))
                    erros.Add(new Erro($"dadosFilme.atores[{indice}].nome", "Informe o nome do ator ou atriz nesse índice informado."));

            }

        }

        private void ValidarDiretoresFilme(List<Diretor> diretores, List<Erro> erros)
        {

            var diretoresInvalidos = diretores.Where(diretor => string.IsNullOrWhiteSpace(diretor.Nome)).ToList();

            for (int indice = 0; indice < diretoresInvalidos.Count; indice++)
            {
                erros.Add(new Erro($"dadosFilme.diretores[{indice}].nome", "Informe o nome do diretor ou diretora nesse índice informado."));
            }

        }

        #endregion

        public SalvarFilmesEmLoteResponseDTO SalvarFilmesEmLote(SalvarFilmesEmLoteRequestDTO request)
        {

            SalvarFilmesEmLoteResponseDTO response;

            try
            {
                ValidarDados(request);

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

        private void ValidarDados(SalvarFilmesEmLoteRequestDTO request)
        {
            List<Erro> erros = new List<Erro>();

            if (request == null || !request.Filmes.HasElements())
                throw new ValidationException("Dados não informados. Favor informá-los.");

            ValidarDadosFilme(request, erros);

            if (erros.Any())
                throw new ValidationException(erros);
        }

        private void ValidarDadosFilme(SalvarFilmesEmLoteRequestDTO request, List<Erro> erros)
        {
            throw new NotImplementedException();
        }
    }
}

