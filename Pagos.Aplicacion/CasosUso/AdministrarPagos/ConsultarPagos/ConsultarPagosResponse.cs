using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagos.Aplicacion.CasosUso.AdministrarPagos.ConsultarPagos
{
    public class ConsultarPagosResponse
    {
        public IEnumerable<ConsultarPagos> Result { get; set; }
    }
    public class ConsultarPagos
    {
        public int IdPago { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public int FormaPago { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string CVV { get; set; }
        public string NombreTitular { get; set; }
        public int NumeroCuotas { get; set; }
    }
}
