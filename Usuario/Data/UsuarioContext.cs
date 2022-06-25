using Microsoft.EntityFrameworkCore;
using usuario.Model;

namespace Usuario.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions <UsuarioContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios {get; set;}
    }
}