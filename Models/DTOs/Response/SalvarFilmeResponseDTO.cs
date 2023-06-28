using Models.ErrorObject;
using System.Net;

namespace Models.DTOs.Response
{
    public class SalvarFilmeResponseDTO : BaseResponseDTO
    {

        public long IdFilmeCriado { get; internal set; }

        public SalvarFilmeResponseDTO(HttpStatusCode codigoStatus, long idFilmeCriado) : base(codigoStatus)
        {
            IdFilmeCriado = idFilmeCriado;
        }

        public SalvarFilmeResponseDTO(HttpStatusCode codigoStatus, Erro erro) : base(codigoStatus, erro)
        {
        }
    }
}
