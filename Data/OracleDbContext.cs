using global_enterprise.Entities;
using Microsoft.EntityFrameworkCore;

namespace global_enterprise.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
        }

        public DbSet<Anteriores> Anteriores { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Proximas> Proximas { get; set; }
        public DbSet<Registro> Registro { get; set; }
        public DbSet<StatusVacina> StatusVacina { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
