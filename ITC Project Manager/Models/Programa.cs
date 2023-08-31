using System;
using System.Collections.Generic;

namespace ITC_Project_Manager.Models;

public partial class Programa
{
    public int Id { get; set; }

    public string? NombrePrograma { get; set; }

    public int Facultad { get; set; }

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    public virtual Facultad FacultadNavigation { get; set; } = null!;
}
