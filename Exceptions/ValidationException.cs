using Models.ErrorObject;
using System.Collections;
using System.Runtime.Serialization;

namespace Exceptions
{
    /// <summary>
    /// Classe de exceção utilizada para quando há algum campo inválido antes de realizar a comunicação com o banco de dados.
    /// </summary>
    [Serializable]
    public class ValidationException : Exception
    {

        public List<Erro> Erros { get; internal set; }
        public IEnumerable ObjetosInvalidos { get; internal set; }

        public ValidationException(IEnumerable objetosInvalidos, string mensagemErro) : this(mensagemErro)
        {
            ObjetosInvalidos = objetosInvalidos;
        }

        /// <summary>
        /// Inicializa uma nova instância da classe ValidationException com uma lista de erros a serem informadas para o usuário.
        /// </summary>
        /// <param name="erros"></param>
        public ValidationException(List<Erro> erros) : base()
        {
            Erros = erros;
        }

        public ValidationException(string mensagemErro) : base(mensagemErro) { }

        protected ValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext) 
            : base(serializationInfo, streamingContext) { }
    }
}
