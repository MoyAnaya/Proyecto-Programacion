using Fiestas.Data;

namespace Fiestas.Repositorio
{
    public interface IFiestasReserva
    {
        Task<List<Reserva>> GetReservas();
        Task<Reserva> GetReserva(int id);
        Task AddReserva(Reserva reserva);
        Task UpdateReserva(Reserva reserva);
        Task DeleteReserva(int id);
        Task<bool> ReservaExists(int id);
        Task<bool> SaveChangesAsync();
        Task<List<Reserva>> ListarReservasAsync();
    }
}
