using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Autenticacion
{
    public int AutenticacionId { get; set; }

    public int UsuarioId { get; set; }

    public string PasswordHash { get; set; } = null!;

    public bool? Mfaenabled { get; set; }

    public DateTime? FechaUltimoLogin { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
