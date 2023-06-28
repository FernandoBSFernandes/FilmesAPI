using Models.DTOs.Objects;
using System.Text.Json.Serialization;

namespace Models.DTOs.Request
{
    public class SalvarFilmeRequestDTO
    {
        [JsonPropertyName("dadosFilme")]
        public Filme DadosFilme { get; internal set; }

        public SalvarFilmeRequestDTO(Filme dadosFilme)
        {
            DadosFilme = dadosFilme;
        }
    }
}
