using Models.ErrorObject;
using System.Runtime.Serialization;

namespace Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {

        public List<Erro> Erros { get; internal set; }

        public ValidationException(List<Erro> erros) : base()
        {
            Erros = erros;
        }

        public ValidationException(string mensagemErro) : base(mensagemErro)
        {
            
        }

        protected ValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext) 
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
