using System;
using System.Collections.Generic;

namespace SistemaEscolar.Models;

public partial class Curso
{
    public int IdCurso { get; set; }

    public string NombreCurso { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int DuracionHoras { get; set; }

    public DateOnly FechaCreacion { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
