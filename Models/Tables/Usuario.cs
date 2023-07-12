using Microsoft.AspNetCore.Identity;

namespace Models.Tables
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; internal set; }
        public DateTime DataCadastro { get; internal set; }
        
        public Usuario(string login) : base(login) { }

    }
}
