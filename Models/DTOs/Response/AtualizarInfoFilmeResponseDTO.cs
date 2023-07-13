using Models.ErrorObject;
using System.Net;

namespace Models.DTOs.Response
{
    public class AtualizarInfoFilmeResponseDTO : BaseResponseDTO
    {

        public AtualizarInfoFilmeResponseDTO() : base(HttpStatusCode.NotFound)
        {
        }

        public AtualizarInfoFilmeResponseDTO(HttpStatusCode codigoStatus) : base(codigoStatus)
        {
        }

        public AtualizarInfoFilmeResponseDTO(HttpStatusCode codigoStatus, Erro erro) : base(codigoStatus, erro)
        {
        }

    }
}
