using AutoMapper;
using BusinessRulesContracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.DTOs.Response;
using Models.ErrorObject;
using Repositories.Context;
using System.Net;

namespace BusinessRulesImpl
{
    public class RemoverFilmesBO : IRemoverFilmesBO
    {

        private readonly FilmeContext context;
        private readonly IConfiguration config;
        private readonly IMapper mapper;

        public RemoverFilmesBO(FilmeContext context, IConfiguration config, IMapper mapper)
        {
            this.context = context;
            this.config = config;
            this.mapper = mapper;
        }

        public RemoverFilmeDTOResponse ExcluirFilme(long id)
        {
            RemoverFilmeDTOResponse response;

            try
            {
                var filmeEncontrado = context.Filme.
                    Include(filme => filme.Diretores).Include(filme => filme.Atores)/*.AsSplitQuery()*/.
                    FirstOrDefault(filme => filme.Id == id);

                if (filmeEncontrado == null)
                    return new RemoverFilmeDTOResponse();

                context.Filme.Remove(filmeEncontrado);

                context.SaveChanges();

                response = new RemoverFilmeDTOResponse(HttpStatusCode.NoContent);

            }
            catch (Exception e)
            {
                response = new RemoverFilmeDTOResponse(HttpStatusCode.InternalServerError, new Erro(e.Message));
            }

            return response;
        }
    }
}
