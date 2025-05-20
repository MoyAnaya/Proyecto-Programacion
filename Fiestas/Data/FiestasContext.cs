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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Salon)
                .WithMany(s => s.Reservas) 
                .HasForeignKey(r => r.SalonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }  
}
