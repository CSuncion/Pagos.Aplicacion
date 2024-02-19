using AutoMapper;
using MediatR;
using Pagos.Aplicacion.Common;
using Pagos.Dominio.Repositorios;

namespace Pagos.Aplicacion.CasosUso.AdministrarPagos.ConsultarPagos
{
    public class ConsultarPagosHandler : IRequestHandler<ConsultarPagosRequest, IResult>
    {
        private readonly IPagosRepository _pagoRepository;
        private readonly IMapper _mapper;

        public ConsultarPagosHandler(IPagosRepository pagosRepository, IMapper mapper)
        {
            _pagoRepository = pagosRepository;
            _mapper = mapper;
        }
        public async Task<IResult> Handle(ConsultarPagosRequest request, CancellationToken cancellationToken)
        {
            IResult result = null;
            try
            {
                var datos = await _pagoRepository.Consultar(request.FiltroPorNombre);
                result = new SuccessResult<IEnumerable<ConsultarPagos>>(
                    _mapper.Map<IEnumerable<ConsultarPagos>>(datos));
                return result;
            }
            catch (Exception ex)
            {
                result = new FailureResult();
                return result;
            }
        }
    }
}
