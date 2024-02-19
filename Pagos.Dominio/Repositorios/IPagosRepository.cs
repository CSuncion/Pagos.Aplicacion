using Pagos.Dominio.Models;

namespace Pagos.Dominio.Repositorios
{
    public interface IPagosRepository : IRepository
    {
        Task<bool> Adicionar(Pago entity);

        Task<bool> Modificar(Pago entity);

        Task<bool> Eliminar(Pago entity);

        Task<Pago> Consultar(int id);

        Task<IEnumerable<Pago>> Consultar(string nombre);
    }
}
