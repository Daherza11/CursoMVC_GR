using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace biblioteca.Models
{
    public partial class bibliotecaModel : DbContext
    {
        public bibliotecaModel()
            : base("name=bibliotecaBDModel")
        {
        }

        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<libro> libro { get; set; }
        public virtual DbSet<prestamo> prestamo { get; set; }
        public DbSet<EstadoCliente> estadosclientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cliente>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<libro>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<libro>()
                .Property(e => e.autor)
                .IsUnicode(false);

            modelBuilder.Entity<libro>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<prestamo>()
                .Property(e => e.estado)
                .IsUnicode(false);
        }
    }
}
