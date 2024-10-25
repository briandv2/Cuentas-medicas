using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Factura
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

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Ip Ips { get; set; } = null!;

    public virtual ICollection<MovimientosFactura> MovimientosFacturas { get; set; } = new List<MovimientosFactura>();
}
