using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string? Nit { get; set; }

    public string TipoUsuario { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Autenticacion> Autenticacions { get; set; } = new List<Autenticacion>();

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    public virtual ICollection<Role> Rols { get; set; } = new List<Role>();
}
