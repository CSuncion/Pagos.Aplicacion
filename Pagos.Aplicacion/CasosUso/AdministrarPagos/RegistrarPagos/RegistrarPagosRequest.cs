using MediatR;
using Pagos.Aplicacion.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagos.Aplicacion.CasosUso.AdministrarPagos.RegistrarPagos
{
    public class RegistrarPagosRequest : IRequest<IResult>
    {
        public decimal Monto { get; set; }
        public int FormaPago { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string CVV { get; set; }
        public string NombreTitular { get; set; }
        public int NumeroCuotas { get; set; }
        public int IdVenta { get; set; }
    }
}
