using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Glosa
{
    public int GlosaId { get; set; }

    public int IddetalleFactura { get; set; }

    public string MotivoGlosa { get; set; } = null!;

    public string TipoDetalle { get; set; } = null!;

    public string? NumeroGlosa { get; set; }

    public string Oficina { get; set; } = null!;

    public string? NumeroRadicacion { get; set; }

    public decimal? ValorGlosa { get; set; }

    public decimal? ValorNetoCuenta { get; set; }

    public DateOnly? FechaRadicacion { get; set; }

    public string EstadoGlosa { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public int? IdMotivoGlosa { get; set; }

    public virtual MotidosDeGlosa? IdMotivoGlosaNavigation { get; set; }

    public virtual DetalleFactura IddetalleFacturaNavigation { get; set; } = null!;

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();
}
