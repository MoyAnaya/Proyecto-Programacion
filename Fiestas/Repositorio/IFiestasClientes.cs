using Fiestas.Data;

namespace Fiestas.Repositorio
{
    public interface IFiestasClientes
    {
        Task<List<Clientes>> GetClientes();
        Task<Clientes> GetCliente(int id);
        Task AddCliente(Clientes cliente);
        Task UpdateCliente(Clientes cliente);
        Task DeleteCliente(Clientes cliente);

        Task<List<Clientes>> ListarClientesAsync();
    }
}