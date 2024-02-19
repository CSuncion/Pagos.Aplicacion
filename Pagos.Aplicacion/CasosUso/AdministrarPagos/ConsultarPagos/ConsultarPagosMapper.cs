using AutoMapper;
using Pagos.Dominio.Models;


namespace Pagos.Aplicacion.CasosUso.AdministrarPagos.ConsultarPagos
{
    public class ConsultarPagosMapper : Profile
    {
        public ConsultarPagosMapper()
        {
            CreateMap<Pago, ConsultarPagos>()
                .ForMember(a => a.IdPago,
                b => b.MapFrom(
                    c => c.IdPago
                    )
                );
        }
    }
}
