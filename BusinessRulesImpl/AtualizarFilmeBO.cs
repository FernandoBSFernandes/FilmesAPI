using AutoMapper;
using BusinessRulesContracts.Interfaces;
using Models.DTOs.Request;
using Models.DTOs.Response;
using Models.ErrorObject;
using Repositories.Context;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Exceptions;
using Util;

namespace BusinessRulesImpl
{
    public class AtualizarFilmeBO : IAtualizarFilmeBO
    {

        private readonly FilmeContext context;
        private readonly IMapper mapper;

        public AtualizarFilmeBO(FilmeContext context, IMapper mapper)
        {
            this.context = context;
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

        public AtualizarInfoFilmeResponseDTO AtualizarInfoFilme(long id, AtualizarInfoFilmeRequestDTO request)
        {
            try
            {
                ValidarDados(request);

                var filmeEncontrado = context.Filme.Where(filme => filme.Id == id)
                    .Include(filme => filme.Diretores).Include(filme => filme.Atores).Include(filme => filme.Estilo)
                    .FirstOrDefault();

                if (filmeEncontrado == null) 
                    return new AtualizarInfoFilmeResponseDTO();

                filmeEncontrado.SetNewValues(request.Filme);

                context.SaveChanges();

                return new AtualizarInfoFilmeResponseDTO(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                var codigoStatus = e is ValidationException ? HttpStatusCode.BadRequest : HttpStatusCode.InternalServerError;
                return new AtualizarInfoFilmeResponseDTO(codigoStatus, new Erro(e.Message));
            }

        }

        private static void ValidarDados(AtualizarInfoFilmeRequestDTO request)
        {
            if (request == null || request.Filme == null)
                throw new ValidationException("Insira os dados do filme que você quer atualizar.");
        }
    }
}
