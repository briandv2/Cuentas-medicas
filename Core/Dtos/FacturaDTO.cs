using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    /// <summary>
    /// DTO for updating the price of a property.
    /// </summary>
    public class FacturaDTO
    {
        public int FacturaId { get; set; }

        public int Ipsid { get; set; }

        public string TipoIdentificacion { get; set; } = null!;

        public string NumeroIdentificacionPrestador { get; set; } = null!;

        public string RazonSocial { get; set; } = null!;

        public string NumeroFactura { get; set; } = null!;

        public decimal ValorFactura { get; set; }

        public DateOnly FechaFactura { get; set; }

        public string EstadoFactura { get; set; } = null!;

        public DateTime? FechaCreacion { get; set; }
    }
}