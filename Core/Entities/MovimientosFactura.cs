using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class MovimientosFactura
{
    public int MovimientoId { get; set; }

    public int FacturaId { get; set; }

    public string DescripcionMovimiento { get; set; } = null!;

    public DateTime? FechaMovimiento { get; set; }

    public virtual Factura Factura { get; set; } = null!;
}
