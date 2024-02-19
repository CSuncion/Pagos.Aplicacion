using FluentValidation;

namespace Pagos.Aplicacion.CasosUso.AdministrarPagos.ConsultarPagos
{
    public class ConsultarPagosValidator : AbstractValidator<ConsultarPagosRequest>
    {
        public ConsultarPagosValidator()
        {
            RuleFor(x => x.FiltroPorNombre)
                .NotEmpty()
                .WithMessage("Debe especificar un nombre del cliente");
        }
    }
}
