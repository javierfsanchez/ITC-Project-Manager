using System;
using System.Collections.Generic;

namespace ITC_Project_Manager.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual ICollection<Administrador> Administradors { get; set; } = new List<Administrador>();

    public virtual ICollection<Docente> Docentes { get; set; } = new List<Docente>();

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
