using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FacturaController"/> class.
        /// </summary>
        /// <param name="propertyService">The property service.</param>
        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        /// <summary>
        /// Creates a new property.
        /// </summary>
        /// <param name="propertyDto">The property DTO.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the action.</returns>
        [HttpPost]
        public async Task<IActionResult> CrearFactura([FromBody] FacturaDTO facturaDTO)
        {
            if (facturaDTO == null)
                return BadRequest("Factura es requerido.");

            try
            {
                await _facturaService.CrearFactura(facturaDTO);
                return Ok("factura creada correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

     
    }
}