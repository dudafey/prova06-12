using Microsoft.EntityFrameworkCore;
using Prova.API.Entities;

namespace Prova.API {
    public class Context : DbContext {

        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FolhaDePagamento> Folhas { get; set; }

    }
}
