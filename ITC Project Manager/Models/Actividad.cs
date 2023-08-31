using System;
using System.Collections.Generic;

namespace ITC_Project_Manager.Models;

public partial class Actividad
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public int? Horas { get; set; }

    public DateTime? Terminar { get; set; }

    public int Estudiante { get; set; }

    public virtual Estudiante EstudianteNavigation { get; set; } = null!;
}
