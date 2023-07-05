using Models.ErrorObject;
using System.Net;
using System.Text.Json.Serialization;

namespace Models.DTOs.Response
{
    public class SalvarFilmeResponseDTO : BaseResponseDTO
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long IdFilmeCriado { get; internal set; }

        public SalvarFilmeResponseDTO(HttpStatusCode codigoStatus, long idFilmeCriado) : base(codigoStatus)
        {
            IdFilmeCriado = idFilmeCriado;
        }

        public SalvarFilmeResponseDTO(HttpStatusCode codigoStatus, Erro erro) : base(codigoStatus, erro)
        { }

        public SalvarFilmeResponseDTO(HttpStatusCode codigoStatus, Erro erro, List<Erro> erros) : base(codigoStatus, erro, erros)
        { }

    }
}
