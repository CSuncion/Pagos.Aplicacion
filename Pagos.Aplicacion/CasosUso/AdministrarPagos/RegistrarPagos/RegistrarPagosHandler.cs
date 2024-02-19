using AutoMapper;
using MediatR;
using Pagos.Aplicacion.Common;
using Pagos.Dominio.Repositorios;
using Models = Pagos.Dominio.Models;

namespace Pagos.Aplicacion.CasosUso.AdministrarPagos.RegistrarPagos
{
    public class RegistrarPagosHandler :
        IRequestHandler<RegistrarPagosRequest, IResult>
    {
        private readonly IPagosRepository _pagosRepository;
        private readonly IMapper _mapper;
        private readonly IRandomGenerator _randomGenerator;
        private class DefaultRandom : IRandomGenerator
        {
            public int Generate(int min, int max)
            {
                return (new Random()).Next(min, max);
            }
        }
        public RegistrarPagosHandler(IPagosRepository pagoRepository, IMapper mapper)
        {
            _pagosRepository = pagoRepository;
            _mapper = mapper;
            _randomGenerator = new DefaultRandom();
        }
        public async Task<IResult> Handle(RegistrarPagosRequest request, CancellationToken cancellationToken)
        {
            IResult result = null;
            try
            {
                var pago = _mapper.Map<Models.Pago>(request);

                var time = _randomGenerator.Generate(1, 11) * 1000;

                await Task.Delay(time);

                if (time <= 5000)
                {
                    var adicionar = await _pagosRepository.Adicionar(pago);
                    if (adicionar)
                        return new SuccessResult();
                    else
                        return new FailureResult();
                }
                else
                    return new FailureResult();
            }
            catch (Exception ex)
            {
                return new FailureResult();
            }
        }
        public interface IRandomGenerator
        {
            int Generate(int min, int max);
        }
    }
}
