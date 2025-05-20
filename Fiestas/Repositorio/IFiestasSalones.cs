using Fiestas.Data;

public interface IFiestasSalones
{
    Task<List<Salones>> GetSalones();
    Task<Salones?> GetSalon(int id);
    Task AddSalon(Salones salon);
    Task UpdateSalon(Salones salon);
    Task DeleteSalon(int id);
    Task<List<Reserva>> ListarSalonesAsync();
    Task UpdateSalones(Salones salon);
}
