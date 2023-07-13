using Models.ErrorObject;
using System.Net;
using System.Text.Json.Serialization;

namespace Models.DTOs
{
    public abstract class BaseResponseDTO
    {
        public HttpStatusCode CodigoStatus { get; internal set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Erro Erro { get; internal set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Erro> Erros { get; set; }

        /// <summary>
        /// Construtor que deve ser chamado em caso de retorno com erro para quem consome a API e espera uma resposta,
        /// </summary>
        protected BaseResponseDTO(HttpStatusCode codigoStatus, Erro erro) : this(codigoStatus)
        {
            Erro = erro;
        }

        /// <summary>
        /// Construtor que deve ser chamado em caso de retorno positivo para quem consome a API e espera uma resposta,
        /// </summary>
        protected BaseResponseDTO(HttpStatusCode codigoStatus)
        {
            CodigoStatus = codigoStatus;
        }

        /// <summary>
        /// Construtor que deve ser chamado em caso de retorno com erro para quem consome a API e espera uma resposta, e quando deve-se retornar uma lista com erros em capos especificados.
        /// </summary>
        protected BaseResponseDTO(HttpStatusCode codigoStatus, Erro erro, List<Erro> erros) : this(codigoStatus, erro)
        {
            Erros = erros;
        }
    }
}
