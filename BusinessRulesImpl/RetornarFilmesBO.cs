using AutoMapper;
using BusinessRulesContracts.Interfaces;
using Microsoft.Extensions.Configuration;
using Models.DTOs.Response;
using Models.ErrorObject;
using Repositories.Context;
using System.Net;

using FilmesFromDTO = Models.DTOs.Objects.Filme;
using FilmesFromDB = Models.Tables.Filme;
using Microsoft.EntityFrameworkCore;

namespace BusinessRulesImpl
{
    public class RetornarFilmesBO : IRetornaFilmesBO
    {

        private readonly FilmeContext context;
        private readonly IConfiguration config;
        private readonly IMapper mapper;

        public RetornarFilmesBO(FilmeContext context, IConfiguration config, IMapper mapper)
        {
            this.context = context;
            this.config = config;
            this.mapper = mapper;
        }

        public RetornaFilmeResponseDTO RetornaFilmePorId(long id)
        {
            RetornaFilmeResponseDTO response;

            try
            {
                var filmeEncontrado = context.Filme.Where(filme => filme.Id == id)
                    .Include(filme => filme.Diretores).Include(filme => filme.Atores).Include(filme => filme.Estilo)
                    .FirstOrDefault();
                
                response = filmeEncontrado is null ? new RetornaFilmeResponseDTO() : 
                    new RetornaFilmeResponseDTO(HttpStatusCode.OK, mapper.Map<FilmesFromDTO>(filmeEncontrado));
            }
            catch (Exception e)
            {
                response = new RetornaFilmeResponseDTO(HttpStatusCode.InternalServerError, new Erro(e.Message));
            }

            return response;
        }

        public RetornaTodosFilmesResponseDTO RetornaTodosFilmes()
        {
            RetornaTodosFilmesResponseDTO response;

            try
            {
                var filmes = context.Filme.
                    Include(filme => filme.Diretores).Include(filme => filme.Atores).Include(filme => filme.Estilo).
                    ToList();

                if (!filmes.Any())
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
