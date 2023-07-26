using AutoMapper;
using BusinessRulesContracts.Interfaces;
using Exceptions;
using Models.DTOs.Objects;
using Models.DTOs.Request;
using Models.DTOs.Response;
using Models.Enum;
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
                return !e.Erros.HasElements()
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
            var erros = new List<Erro>();

            if (request == null || request.DadosFilme == null)
                throw new ValidationException("Dados não informados. Favor informá-los.");

            ValidarDadosFilme(request, erros);

            if (erros.HasElements())
                throw new ValidationException(erros);

            ValidarPreenchimentoDados(request.DadosFilme, erros);

            if (erros.HasElements())
                throw new ValidationException(erros);
        }

        #region Validação do preenchimento de informações de um filme

        private void ValidarDadosFilme(SalvarFilmeRequestDTO request, List<Erro> erros)
        {
            if (string.IsNullOrWhiteSpace(request.DadosFilme.Nome))
                erros.Add(new Erro("dadosFilme.nome", "Campo Obrigatório."));

            if (!request.DadosFilme.Duracao.HasValue)
                erros.Add(new Erro("dadosFilme.duracao", "Campo Obrigatório."));

            if (!request.DadosFilme.Ano.HasValue)
                erros.Add(new Erro("dadosFilme.ano", "Campo Obrigatório."));

            if (request.DadosFilme.Estilo == null)
                erros.Add(new Erro("dadosFilme.Estilo", "Instancie um estilo para o filme."));

            else if (string.IsNullOrWhiteSpace(request.DadosFilme.Estilo.Descricao))
                erros.Add(new Erro("dadosFilme.estilo.descricao", "Campo obrigatório."));

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

        #region Validação dos dados preenchidos, para checar se os dados preenchidos atendem alguns requisitos.

        private void ValidarPreenchimentoDados(FilmesFromDTO filme, List<Erro> erros)
        {
            if (filme.Nome.Trim().Length > 60)
                erros.Add(new Erro("dadosFilme.nome", "O nome do filme precisa conter até 60 caracteres."));

            if (filme.Duracao.Value is < 60 or > 240)
                erros.Add(new Erro("dadosFilme.duracao", "O filme precisa ter entre 60 e 240 minutos."));

            if (filme.Ano.Value is < 1900 or > 3000)
                erros.Add(new Erro("dadosFilme.ano", "O filme deve ter origem entre 1900 e 3000 (sim, colocamos 3000, mas sabemos que está distante)."));

            if (filme.Estilo.Descricao.Length is > 50)
                erros.Add(new Erro("dadosFilme.estilo.descricao", "O estilo do seu filme está muito grande. O máximo é de 50 caracteres."));

            ValidarDadosPreenchidosComplementares(filme, erros);

        }

        private void ValidarDadosPreenchidosComplementares(FilmesFromDTO filme, List<Erro> erros)
        {
            ValidarDadosAtores(filme.Atores, erros);
            ValidarDadosDiretores(filme.Diretores, erros);
        }

        private void ValidarDadosAtores(List<Ator> atores, List<Erro> erros)
        {
            atores.ForEach(ator =>
            {
                int index = atores.IndexOf(ator);

                if (ator.Nome.Length > 100)
                    erros.Add(new Erro($"dadosFilme.atores[{index}].nome", "O nome do ator ou da atriz no indice informado excedeu o tamanho máximo de 100 caracteres."));

                if (!Enum.IsDefined(typeof(Papel), ator.Papel.Value))
                    erros.Add(new Erro($"dadosFilme.atores[{index}].papel",
                        "O valor inserido para o papel não existe. Insira como valor \"Protagonista\", \"Antagonista\", \"Coadjuvante\" ou \"Complementar\"."));

            });
        }

        private void ValidarDadosDiretores(List<Diretor> diretores, List<Erro> erros)
        {
            diretores.ForEach(diretor =>
            {
                int posicao = diretores.IndexOf(diretor);

                if (diretor.Nome.Length > 100)
                    erros.Add(new Erro($"dadosFilme.diretores[{posicao}].nome", "O nome do(a) diretor(a) no indice informado excedeu o tamanho máximo de 100 caracteres."));

            });
        }

        #endregion

        #endregion

        #region Salvamento em lote de varios filmes de uma vez
        public async Task<SalvarFilmesEmLoteResponseDTO> SalvarFilmesEmLoteAsync(SalvarFilmesEmLoteRequestDTO request)
        {

            SalvarFilmesEmLoteResponseDTO response;

            try
            {
                ValidarDados(request);

                var filmes = mapper.Map<List<FilmesFromDB>>(request.Filmes);

                await context.Filme.AddRangeAsync(filmes);
                await context.SaveChangesAsync();

                List<DadosFilmeCriado> dadosFilmesCriado = filmes.Select(filme => new DadosFilmeCriado(filme.Nome, filme.Id)).ToList();

                response = new SalvarFilmesEmLoteResponseDTO(HttpStatusCode.Created, dadosFilmesCriado);

            }
            catch (ValidationException ex)
            {
                response = new SalvarFilmesEmLoteResponseDTO(HttpStatusCode.BadRequest, new Erro(ex.Message), (List<FilmesFromDTO>)ex.ObjetosInvalidos);
            }
            catch (Exception e)
            {
                response = new SalvarFilmesEmLoteResponseDTO(HttpStatusCode.InternalServerError, new Erro(e.Message));
            }

            return response;
        }

        private void ValidarDados(SalvarFilmesEmLoteRequestDTO request)
        {
            if (request == null || !request.Filmes.HasElements())
                throw new ValidationException("Dados não informados. Favor informá-los.");

            bool listaFilmesContemDadosObrigatoriosNaoPreenchidos = ValidarDadosFilme(request);

            if (listaFilmesContemDadosObrigatoriosNaoPreenchidos)
                throw new ValidationException("O seu request possui erros de validação, pois alguns dados obrigatórios não estão preenchidos. Favor verificar.");

            var filmesComDadosInvalidos = ValidarDadosPreenchidos(request);

            if (filmesComDadosInvalidos)
                throw new ValidationException("O seu request possui erros de validação, pois alguns dados obrigatórios estão preenchidos de forma inválida.");
        }

        #region Validação Obrigatoria dos Dados presente na lista de filmes do request.

        /// <summary>
        /// Verifica se algum dado na coleção de filmes a serem persistidos não foi preenchido. Caso se confirme, uma lista com elementos que possuem um dado inválido será criada.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Uma lista com componentes que possuem campos obrigatórios não preenchidos.</returns>
        private bool ValidarDadosFilme(SalvarFilmesEmLoteRequestDTO request)
        {

            var filmesComDadosObrigatoriosNaoPreenchidos = request.Filmes.Exists(filme =>
            {
                var propriedadesFilmeNaoPossuiValor = string.IsNullOrWhiteSpace(filme.Nome) || !filme.Duracao.HasValue || !filme.Ano.HasValue;

                var filmeNaoPossuiEstilo = filme.Estilo == null || string.IsNullOrWhiteSpace(filme.Estilo.Descricao);

                var listaDiretoresSemValor = filme.Diretores == null || !filme.Diretores.Any() || filme.Diretores.Exists(diretor => string.IsNullOrWhiteSpace(diretor.Nome));

                var filmeComAtoresSemValor = filme.Atores == null || !filme.Atores.Any() || filme.Atores.Exists(ator => string.IsNullOrWhiteSpace(ator.Nome) || !ator.Papel.HasValue);

                return propriedadesFilmeNaoPossuiValor || filmeNaoPossuiEstilo || listaDiretoresSemValor || filmeComAtoresSemValor;
            });

            return filmesComDadosObrigatoriosNaoPreenchidos;

        }

        #endregion

        #region Validação do que foi preenchido na lista de filmes

        private bool ValidarDadosPreenchidos(SalvarFilmesEmLoteRequestDTO request)
        {
            bool filmesComErroDeValidacao = request.Filmes.Exists(filme =>
            {
                var filmesComNomeGrande = filme.Nome.Trim().Length > 60;

                var filmeComDuracaoForaDoEsperado = filme.Duracao.Value is < 60 or > 240;

                var filmeComAnoForaDoRange = filme.Ano.Value is < 1900 or > 3000;

                var filmeComDescricaoGrande = filme.Estilo.Descricao.Length is > 50;

                var dadosAtoresOuDiretoresInvalidos = ValidarDadosAtoresEDiretores(filme);

                return filmesComNomeGrande || filmeComDuracaoForaDoEsperado || filmeComAnoForaDoRange || filmeComDescricaoGrande || dadosAtoresOuDiretoresInvalidos;
            });

            return filmesComErroDeValidacao;

        }

        private bool ValidarDadosAtoresEDiretores(FilmesFromDTO filme)
        {
            bool dadosAtoresInvalidos = ValidarDadosAtores(filme.Atores);
            bool dadosDiretoresInvalidos = ValidarDadosDiretores(filme.Diretores);

            return dadosAtoresInvalidos || dadosDiretoresInvalidos;
        }

        private bool ValidarDadosAtores(List<Ator> atores) => atores.Exists(ator => ator.Nome.Length > 100 || !Enum.IsDefined(typeof(Papel), ator.Papel.Value));

        private bool ValidarDadosDiretores(List<Diretor> diretores) => diretores.Exists(diretor => diretor.Nome.Length > 100);

        #endregion


        #endregion

    }
}

