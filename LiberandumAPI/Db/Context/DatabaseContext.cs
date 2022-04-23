using Microsoft.EntityFrameworkCore;
using WebApplication3.Db.Context;
using WebApplication3.Models;

namespace LiberandumAPI.Db.Context {
    public class DatabaseContext : DbContext {
        public readonly static DatabaseContext Instance = new DatabaseContext();

        private DatabaseContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured) {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseOracle(config.GetConnectionString("FIAPConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Perfil>().HasOne(p => p.Usuario).WithMany(u => u.Perfis);
            modelBuilder.Entity<Perfil>().Navigation(p => p.Usuario).AutoInclude();
            modelBuilder.Entity<Perfil>().HasOne(p => p.Categoria).WithMany(c => c.Perfis);
            modelBuilder.Entity<Perfil>().Navigation(p => p.Categoria).AutoInclude();

            modelBuilder.Entity<Evento>().HasOne(e => e.Perfil).WithMany(p => p.Eventos);
            modelBuilder.Entity<Evento>().HasOne(e => e.Necessidade).WithMany(n => n.Eventos);
            modelBuilder.Entity<Evento>().Navigation(e => e.Necessidade).AutoInclude();

        }

        public static bool StartDb() {
            try {
                var Db = Instance;

                Db.Database.EnsureDeleted();
                return Db.Database.EnsureCreated();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<Perfil>? Perfil { get; set; }
        public DbSet<Necessidade>? Necessidade { get; set; }
        public DbSet<Categoria>? Categoria { get; set; }
        public DbSet<Evento>? Evento { get; set; }

    }
}
