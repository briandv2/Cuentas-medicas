using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Cup
{
    public int Cupsid { get; set; }

    public string Nombre { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();
}
