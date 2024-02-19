using MediatR;
using Pagos.Aplicacion.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagos.Aplicacion.CasosUso.AdministrarPagos.ConsultarPagos
{
    public class ConsultarPagosRequest : IRequest<IResult>
    {
        public string FiltroPorNombre { get; set; }
    }
}
