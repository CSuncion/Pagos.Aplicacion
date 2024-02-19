using AutoMapper;
using Models = Pagos.Dominio.Models;

namespace Pagos.Aplicacion.CasosUso.AdministrarPagos.RegistrarPagos
{
    public class RegistrarPagosMapper : Profile
    {
        public RegistrarPagosMapper()
        {
            CreateMap<RegistrarPagosRequest, Models.Pago>();
        }
    }
}
