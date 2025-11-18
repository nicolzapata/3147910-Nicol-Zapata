using System;
using System.Collections.Generic;

namespace SistemaEscolar.Models;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }

    public string Documento { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
