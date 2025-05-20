using Fiestas.Data;
using Microsoft.EntityFrameworkCore;

namespace Fiestas.Repositorio
{
    public class FiestasSalones : IFiestasSalones
    {
        private readonly FiestasContext _context;

        public FiestasSalones(FiestasContext context)
        {
            _context = context;
        }

        public async Task<List<Salones>> GetSalones()
        {
            return await _context.Salones.ToListAsync();
        }

        public async Task<Salones> GetSalon(int id)
        {
            return await _context.Salones.FindAsync(id);
        }

        public async Task AddSalon(Salones salon)
        {
            _context.Salones.Add(salon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSalon(Salones salon)
        {
            var existente = await _context.Salones.FindAsync(salon.Id);
            if (existente != null)
            {
                existente.Nombre = salon.Nombre;
                existente.Ubicacion = salon.Ubicacion;
                existente.Capacidad = salon.Capacidad;
                existente.Precio = salon.Precio;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSalon(int id)
        {
            var salon = await _context.Salones.FindAsync(id);
            if (salon != null)
            {
                _context.Salones.Remove(salon);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<Reserva>> ListarSalonesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateSalones(Salones salon)
        {
            throw new NotImplementedException();
        }
    }
}
