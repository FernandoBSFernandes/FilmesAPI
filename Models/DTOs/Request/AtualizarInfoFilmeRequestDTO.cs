using Models.DTOs.Objects;
using System.Text.Json.Serialization;

namespace Models.DTOs.Request
{
    public class AtualizarInfoFilmeRequestDTO
    {
        [JsonPropertyName("filme")]
        public Filme Filme { get; internal set; }

        public AtualizarInfoFilmeRequestDTO(Filme filme)
        {
            Filme = filme;
        }
    }
}
