using System;
using System.Collections.Generic;

namespace ITC_Project_Manager.Models;

public partial class Docente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public string? Telefono { get; set; }

    public int Usuario { get; set; }

    public int Presentación { get; set; }

    public virtual Presentacion PresentaciónNavigation { get; set; } = null!;

    public virtual ICollection<Supervisor> Supervisors { get; set; } = new List<Supervisor>();

    public virtual Usuario UsuarioNavigation { get; set; } = null!;
}
