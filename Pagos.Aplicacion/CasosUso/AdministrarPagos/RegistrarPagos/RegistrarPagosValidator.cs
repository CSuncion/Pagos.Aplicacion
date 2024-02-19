using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagos.Aplicacion.CasosUso.AdministrarPagos.RegistrarPagos
{
    public class RegistrarPagosValidator : AbstractValidator<RegistrarPagosRequest>
    {
        public RegistrarPagosValidator()
        {
            RuleFor(x => x.FormaPago)
                .Equal(1)
                .WithMessage("solo se aceptan pagos con tarjeta de crédito");
        }
    }
}
