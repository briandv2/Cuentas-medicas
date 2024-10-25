using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class MotidosDeGlosa
{
    public int IdmotivoGlosa { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Glosa> Glosas { get; set; } = new List<Glosa>();
}
