using Models.DTOs.Objects;
using Models.ErrorObject;
using System.Net;

namespace Models.DTOs.Response
{
    public class RetornaFilmeResponseDTO : BaseResponseDTO
    {

        public Filme Filme { get; internal set; }

        /// <summary>
        /// Construtor utilizado para identificar que o filme não foi encontrado. O retorno não se caracteriza como necessariamente negativo, pois nenhuma exceção foi lançada.
        /// </summary>
        public RetornaFilmeResponseDTO() : base(HttpStatusCode.NotFound)
        {
        }

        public RetornaFilmeResponseDTO(HttpStatusCode codigoStatus, Filme filme) : base(codigoStatus)
        {
            Filme = filme;
        }

        public RetornaFilmeResponseDTO(HttpStatusCode codigoStatus, Erro erro) : base(codigoStatus, erro)
        {
        }
    }
}
