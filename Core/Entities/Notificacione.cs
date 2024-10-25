using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Notificacione
{
    public int NotificacionId { get; set; }

    public int UsuarioId { get; set; }

    public int? GlosaId { get; set; }

    public string Mensaje { get; set; } = null!;

    public DateTime? FechaNotificacion { get; set; }

    public bool? Estado { get; set; }

    public virtual Glosa? Glosa { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
