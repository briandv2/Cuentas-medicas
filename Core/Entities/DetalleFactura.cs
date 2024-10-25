using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class DetalleFactura
{
    public int IddetalleFactura { get; set; }

    public int Idfactura { get; set; }

    public int Idcups { get; set; }

    public decimal Valor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Glosa> Glosas { get; set; } = new List<Glosa>();

    public virtual Cup IdcupsNavigation { get; set; } = null!;

    public virtual Factura IdfacturaNavigation { get; set; } = null!;
}
