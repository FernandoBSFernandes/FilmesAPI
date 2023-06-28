using AutoMapper;
using BusinessRulesContracts.Interfaces;
using Microsoft.Extensions.Configuration;
using Models.DTOs.Response;
using Repositories.Context;
using System.Net;

using FilmesFromDTO = Models.DTOs.Objects.Filme;
using FilmesFromDB = Models.Tables.Filme;
using Models.ErrorObject;

namespace BusinessRulesImpl
{
    public class RetornaTodosFilmesBO : IRetornaTodosFilmesBO
    {

        private readonly FilmeContext context;
        private readonly IConfiguration config;
        private readonly IMapper mapper;

        public RetornaTodosFilmesBO(FilmeContext context, IConfiguration config, IMapper mapper)
        {
            this.context = context;
            this.config = config;
            this.mapper = mapper;
        }

        public RetornaTodosFilmesResponseDTO RetornaTodosFilmes()
        {
            RetornaTodosFilmesResponseDTO response;

            try
            {
                var filmes = context.Filme.ToList();

                if(!filmes.Any())
                    filmes = Enumerable.Empty<FilmesFromDB>().ToList();

                var filmesToDTO = mapper.Map<List<FilmesFromDB>, List<FilmesFromDTO>>(filmes);

                response = new RetornaTodosFilmesResponseDTO(HttpStatusCode.OK, filmesToDTO);

            }
            catch (Exception e)
            {
                response = new RetornaTodosFilmesResponseDTO(HttpStatusCode.InternalServerError, new Erro(e.Message));
            }

            return response;
        }
    }
}
