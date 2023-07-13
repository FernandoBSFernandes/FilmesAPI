using Models.DTOs.Objects;
using Models.ErrorObject;
using System.Net;
using System.Text.Json.Serialization;

namespace Models.DTOs.Response
{
    public class RetornaTodosFilmesResponseDTO : BaseResponseDTO
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<Filme> Filmes { get; internal set; }

        public RetornaTodosFilmesResponseDTO(HttpStatusCode codigoStatus, List<Filme> filmes) : base(codigoStatus)
        {
            Filmes = filmes;
        }

        public RetornaTodosFilmesResponseDTO(HttpStatusCode codigoErro, Erro erro) : base(codigoErro, erro)
        { }

        /// <summary>
        /// Construtor utilizado para identificar que não há filmes cadastrados. O retorno não se caracteriza como necessariamente negativo, pois nenhuma exceção foi lançada.
        /// </summary>
        public RetornaTodosFilmesResponseDTO() : base(HttpStatusCode.NotFound)
        { }

    }
}
