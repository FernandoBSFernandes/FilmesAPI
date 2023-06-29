using Models.DTOs.Objects;
using Models.ErrorObject;
using System.Net;

namespace Models.DTOs.Response
{
    public class AtualizarFilmeResponseDTO : BaseResponseDTO
    {

        /// <summary>
        /// Construtor utilizado para identificar que o filme a ser atualizado com o que ID que foi informado não foi encontrado. O retorno não se caracteriza como necessariamente negativo, pois nenhuma exceção foi lançada.
        /// </summary>
        public AtualizarFilmeResponseDTO() : base(HttpStatusCode.NotFound)
        {
        }

        public AtualizarFilmeResponseDTO(HttpStatusCode codigoStatus) : base(codigoStatus)
        {
        }

        public AtualizarFilmeResponseDTO(HttpStatusCode codigoStatus, Erro erro) : base(codigoStatus, erro)
        {
        }
    }
}
