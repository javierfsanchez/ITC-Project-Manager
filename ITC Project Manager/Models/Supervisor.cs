using System;
using System.Collections.Generic;

namespace ITC_Project_Manager.Models;

public partial class Supervisor
{
    public int Id { get; set; }

    public int Proyecto { get; set; }

    public string? Motivo { get; set; }

    public int? Docente { get; set; }

    public virtual Docente? DocenteNavigation { get; set; }

    public virtual Proyecto ProyectoNavigation { get; set; } = null!;
}
