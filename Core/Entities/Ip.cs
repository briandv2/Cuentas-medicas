using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Ip
{
    public int Ipsid { get; set; }

    public string Nombre { get; set; } = null!;

    public string Nit { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
