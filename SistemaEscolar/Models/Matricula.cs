using System;
using System.Collections.Generic;

namespace SistemaEscolar.Models;

public partial class Matricula
{
    public int IdMatricula { get; set; }

    public int IdEstudiante { get; set; }

    public int IdCurso { get; set; }

    public DateOnly FechaMatricula { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Curso IdCursoNavigation { get; set; } = null!;

    public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;
}
