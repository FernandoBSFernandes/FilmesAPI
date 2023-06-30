using Models.ErrorObject;
using System.Net;

namespace Models.DTOs.Response
{
    public class RemoverFilmeDTOResponse : BaseResponseDTO
    {

        public RemoverFilmeDTOResponse() : base(HttpStatusCode.NotFound)
        {
        }

        public RemoverFilmeDTOResponse(HttpStatusCode codigoStatus) : base(codigoStatus)
        {
        }

        public RemoverFilmeDTOResponse(HttpStatusCode codigoStatus, Erro erro) : base(codigoStatus, erro)
        {
        }
    }
}
