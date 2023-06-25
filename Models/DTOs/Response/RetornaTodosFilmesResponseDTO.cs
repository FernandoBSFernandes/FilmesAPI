using Models.DTOs.Objects;
using System.Net;

namespace Models.DTOs.Response
{
    public class RetornaTodosFilmesResponseDTO : BaseResponseDTO
    {
        public List<Filme> Filmes { get; set; }

        public RetornaTodosFilmesResponseDTO(HttpStatusCode codigoStatus, List<Filme> filmes) : base(codigoStatus)
        {
            Filmes = filmes;
        }
    }
}
