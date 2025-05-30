using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Fiestas.Data
{
    public class FiestasContext : DbContext
    {
        public FiestasContext(DbContextOptions<FiestasContext> options) : base(options)
        {
        }

        public DbSet<Salones> Salones { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura Reserva → Cliente con DELETE CASCADE
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cliente)
                .WithMany()
                .HasForeignKey(r => r.ClienteId)
                .OnDelete(DeleteBehavior.Cascade); // Esto está bien

            // Configura Reserva → Salon SIN DELETE CASCADE
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Salon)
                .WithMany()
                .HasForeignKey(r => r.SalonId)
                .OnDelete(DeleteBehavior.Restrict); // <== Aquí evitas el ciclo

            // (Opcional) Configura precisión del campo Precio
            modelBuilder.Entity<Salones>()
                .Property(s => s.Precio)
                .HasColumnType("decimal(18,2)");
        }
    }
}
