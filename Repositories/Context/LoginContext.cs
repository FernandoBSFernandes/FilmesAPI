using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Tables;

namespace Repositories.Context
{
    public class LoginContext : IdentityDbContext<Usuario>
    {

        public LoginContext(DbContextOptions<LoginContext> options) : base(options) {}
        
    }
}
