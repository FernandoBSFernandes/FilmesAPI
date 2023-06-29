using Models.DTOs.Objects;
using System.Text.Json.Serialization;

namespace Models.DTOs.Request
{
    public class AtualizarFilmeRequestDTO
    {
        [JsonPropertyName("filme")]
        public Filme Filme { get; set; }

    }
}
