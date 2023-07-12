using Models.DTOs.Objects;
using System.Text.Json.Serialization;

namespace Models.DTOs.Request
{
    public class CriarUsuarioDTORequest
    {

        [JsonPropertyName("dadosNovoUsuario")]
        public Usuario Usuario { get; internal set; }

        public CriarUsuarioDTORequest(Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}
