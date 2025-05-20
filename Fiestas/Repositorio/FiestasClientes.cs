using Microsoft.EntityFrameworkCore;
using Fiestas.Data;


namespace Fiestas.Repositorio
{
    public class FiestasClientes : IFiestasClientes
    {
        private readonly FiestasContext _context;
        public FiestasClientes(FiestasContext context)
        {
            _context = context;
        }
        public async Task<List<Clientes>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<Clientes> GetCliente(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }
        public async Task AddCliente(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCliente(Clientes cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCliente(Clientes cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Clientes>> ListarClientesAsync()
        {
             return await _context.Clientes.ToListAsync();
            
        }

    }   
}
