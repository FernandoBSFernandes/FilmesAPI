using Models.DTOs.Objects;
using Models.ErrorObject;
using System.Net;
using System.Text.Json.Serialization;

namespace Models.DTOs.Response
{
    public class SalvarFilmesEmLoteResponseDTO : BaseResponseDTO
    {
        [JsonPropertyName("dadosFilmesCriado")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<DadosFilmeCriado> DadosFilmesCriado { get; set; }

        public SalvarFilmesEmLoteResponseDTO(HttpStatusCode codigoStatus, List<DadosFilmeCriado> dadosFilmesCriado) : base(codigoStatus)
        {
            DadosFilmesCriado = dadosFilmesCriado;
        }

        public SalvarFilmesEmLoteResponseDTO(HttpStatusCode codigoStatus, Erro erro) : base(codigoStatus, erro)
        {
        }
    }
}
