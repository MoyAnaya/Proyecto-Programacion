using Fiestas.Data;
using Microsoft.EntityFrameworkCore;

namespace Fiestas.Repositorio
{
    public class FiestasReserva : IFiestasReserva
    {
        private readonly FiestasContext _context;
        public FiestasReserva(FiestasContext context)
        {
            _context = context;
        }

        public async Task<List<Reserva>> GetReservas()
        {
            return await _context.Reservas.ToListAsync();
        }

        public async Task<Reserva> GetReserva(int id)
        {
            return await _context.Reservas
                                 .Include(r => r.Cliente)
                                 .Include(r => r.Salon)
                                 .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddReserva(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReserva(Reserva reserva)
        {
            var existente = await _context.Reservas.FindAsync(reserva.Id);

            if (existente == null)
                throw new InvalidOperationException("La reserva no existe o fue eliminada.");

            existente.ClienteId = reserva.ClienteId;
            existente.SalonId = reserva.SalonId;
            existente.fecha = reserva.fecha;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Reserva>> ListarReservasAsync()
        {
            return await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Salon)
                .ToListAsync();
        }
        public async Task<bool> ReservaExists(int id)
        {
            return await _context.Reservas.AnyAsync(e => e.Id == id);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

