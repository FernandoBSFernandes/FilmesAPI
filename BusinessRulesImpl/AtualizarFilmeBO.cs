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
using Microsoft.EntityFrameworkCore;

namespace BusinessRulesImpl
{
    public class AtualizarFilmeBO : IAtualizarFilmeBO
    {

        private readonly FilmeContext context;
        private readonly IConfiguration config;
        private readonly IMapper mapper;

        public AtualizarFilmeBO(FilmeContext context, IConfiguration config, IMapper mapper)
        {
            this.context = context;
            this.config = config;
            this.mapper = mapper;
        }

        public AtualizarFilmeResponseDTO AtualizarFilme(AtualizarFilmeRequestDTO request, long id)
        {
            AtualizarFilmeResponseDTO response;

            try
            {
                var filmeEncontrado = context.Filme.Where(filme => filme.Id == id)
                    .Include(filme => filme.Diretores).Include(filme => filme.Atores).Include(filme => filme.Estilo)
                    .FirstOrDefault();

                if (filmeEncontrado == null)
                    return new AtualizarFilmeResponseDTO();

                var filmeASerAtualizado = mapper.Map(request.Filme, filmeEncontrado);

                context.Filme.Update(filmeASerAtualizado);

                context.SaveChanges();

                response = new AtualizarFilmeResponseDTO(HttpStatusCode.NoContent);

            }
            catch (Exception e)
            {
                response = new AtualizarFilmeResponseDTO(HttpStatusCode.InternalServerError, new Erro(e.Message));
            }

            return response;
        }
    }
}
