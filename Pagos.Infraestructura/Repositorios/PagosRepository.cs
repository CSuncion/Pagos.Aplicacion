using Microsoft.EntityFrameworkCore;
using Pagos.Dominio.Models;
using Pagos.Dominio.Repositorios;
using Pagos.Infraestructura.Repositorios.Base;


namespace Pagos.Infraestructura.Repositorios
{
    public class PagosRepository : IPagosRepository
    {
        private readonly PagosDbContext _context;

        public PagosRepository(PagosDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Adicionar(Pago entity)
        {
            try
            {
                _context.Pagos.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<Pago> Consultar(int id)
        {
            return await _context.Pagos.FindAsync(id);
        }
        public async Task<IEnumerable<Pago>> Consultar(string nombre)
        {
            return await _context.Pagos.Where(p => p.NombreTitular.Contains(nombre)).ToListAsync();
        }
        public Task<bool> Eliminar(Pago entity)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> Modificar(Pago entity)
        {
            try
            {
                Pago p = await _context.Pagos.FindAsync(entity.IdPago);

                p.Monto = entity.Monto;
                p.FormaPago = entity.FormaPago;
                p.NumeroTarjeta = entity.NumeroTarjeta;
                p.FechaVencimiento = entity.FechaVencimiento;
                p.CVV = entity.CVV;
                p.NombreTitular = entity.NombreTitular;
                p.NumeroCuotas = entity.NumeroCuotas;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
