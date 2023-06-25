using Models.ErrorObject;
using System.Net;

namespace Models.DTOs
{
    public class BaseResponseDTO
    {
        
        public HttpStatusCode CodigoStatus { get; internal set; }
        public Erro Erro { get; internal set; }

        /// <summary>
        /// Construtor que deve ser chamado em caso de retorno com erro para quem consome a API e espera uma resposta,
        /// </summary>
        /// <param name="codigoStatus"></param>
        /// <param name="erro"></param>
        public BaseResponseDTO(HttpStatusCode codigoStatus, Erro erro) : this(codigoStatus)
        {
            Erro = erro;
        }

        /// <summary>
        /// Construtor que deve ser chamado em caso de retorno positivo para quem consome a API e espera uma resposta,
        /// </summary>
        /// <param name="codigoStatus"></param>
        public BaseResponseDTO(HttpStatusCode codigoStatus)
        {
            CodigoStatus = codigoStatus;
        }
    }
}
