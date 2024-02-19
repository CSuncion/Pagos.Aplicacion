using AutoMapper;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Pagos.Aplicacion.CasosUso.AdministrarPagos.RegistrarPagos;
using Pagos.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pagos.Aplicacion.CasosUso.AdministrarPagos.RegistrarPagos.RegistrarPagosHandler;

namespace Pagos.Test.Aplicacion.Testes
{
    public class AdministrarPagosTests
    {
        private readonly IPagosRepository _pagoRepository;
        private readonly IMapper _mapper;
        private readonly RegistrarPagosHandler _registrarPagosHandler;
        private readonly IRandomGenerator _generator;
        public AdministrarPagosTests()
        {
            _pagoRepository = Substitute.For<IPagosRepository>();
            _mapper = Substitute.For<IMapper>();
            _generator = Substitute.For<IRandomGenerator>();
            _registrarPagosHandler = Substitute.For<RegistrarPagosHandler>(_pagoRepository, _mapper);
        }

        [Fact]
        public async Task RegistrarPagosOK()
        {
            var request = new RegistrarPagosRequest() { IdVenta = 123 };
            CancellationTokenSource cts = new();
            CancellationToken cancellationToken = cts.Token;
            Random rnd = new Random();

            //Escenarios
            _generator.Generate(default, default).ReturnsForAnyArgs(1);
            _pagoRepository.Adicionar(default).ReturnsForAnyArgs(true);

            cts.Cancel();
            var retorno = await _registrarPagosHandler.Handle(request, cancellationToken);

            Assert.True(retorno.HasSucceeded);
        }

        [Fact]
        public async Task RegistrarPagosError()
        {
            var request = new RegistrarPagosRequest() { IdVenta = 123 };
            CancellationTokenSource cts = new();
            CancellationToken cancellationToken = cts.Token;

            _generator.Generate(default, default).ReturnsForAnyArgs(1);
            _pagoRepository.Adicionar(default).ReturnsForAnyArgs(false);

            cts.Cancel();
            var retorno = await _registrarPagosHandler.Handle(request, cancellationToken);

            Assert.False(retorno.HasSucceeded);
        }

        [Fact]
        public async Task RegistrarPagosException()
        {
            var request = new RegistrarPagosRequest() { IdVenta = 123 };
            CancellationTokenSource cts = new();
            CancellationToken cancellationToken = cts.Token;

            _generator.Generate(default, default).ReturnsForAnyArgs(1);
            _pagoRepository.Adicionar(default).ThrowsForAnyArgs<Exception>();

            cts.Cancel();
            Assert.ThrowsAnyAsync<Exception>(async () =>
            {
                await _registrarPagosHandler.Handle(request, cancellationToken);
            });
        }
    }
}
