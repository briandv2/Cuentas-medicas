using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Reporte
{
    public int ReporteId { get; set; }

    public string NombreReporte { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaGeneracion { get; set; }

    public string RutaReporte { get; set; } = null!;
}
