using System;
using System.Collections.Generic;

namespace ITC_Project_Manager.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int? Telefono { get; set; }

    public string TipoIdentificacion { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public int Programa { get; set; }

    public int Proyecto { get; set; }

    public int Usuario { get; set; }

    public virtual ICollection<Actividad> Actividads { get; set; } = new List<Actividad>();

    public virtual Programa ProgramaNavigation { get; set; } = null!;

    public virtual Proyecto ProyectoNavigation { get; set; } = null!;

    public virtual Usuario UsuarioNavigation { get; set; } = null!;
}
