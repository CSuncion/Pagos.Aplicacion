using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pagos.Aplicacion.CasosUso.AdministrarPagos.ConsultarPagos;
using Pagos.Aplicacion.CasosUso.AdministrarPagos.RegistrarPagos;

namespace Pagos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configInfo;
        public PagosController(IMediator mediator, IConfiguration configInfo)
        {
            _mediator = mediator;
            _configInfo = configInfo;
        }
        [HttpGet("consultar")]
        public async Task<IActionResult> Consultar([FromQuery] ConsultarPagosRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistrarPagosRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
