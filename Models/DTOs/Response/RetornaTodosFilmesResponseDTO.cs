using Models.DTOs.Objects;
using Models.ErrorObject;
using System.Net;

namespace Models.DTOs.Response
{
    public class RetornaTodosFilmesResponseDTO : BaseResponseDTO
    {
        public List<Filme> Filmes { get; internal set; }

        public RetornaTodosFilmesResponseDTO(HttpStatusCode codigoStatus, List<Filme> filmes) : base(codigoStatus)
        {
            Filmes = filmes;
        }

        public RetornaTodosFilmesResponseDTO(HttpStatusCode codigoErro, Erro erro) : base(codigoErro, erro)
        { }

    }
}
