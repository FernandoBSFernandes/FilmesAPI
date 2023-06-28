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
                var filme = mapper.Map<FilmesFromDTO, FilmesFromDB>(request.DadosFilme);

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
    }
}

