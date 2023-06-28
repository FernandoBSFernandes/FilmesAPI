using Models.Enum;
using System.Text.Json.Serialization;

namespace Models.DTOs.Objects
{
    public class Ator
    {
        public string Nome { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Papel Papel { get; set; }
    }
}