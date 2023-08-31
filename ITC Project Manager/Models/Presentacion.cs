using System;
using System.Collections.Generic;

namespace ITC_Project_Manager.Models;

public partial class Presentacion
{
    public int Id { get; set; }

    public DateTime? DiaPresentacion { get; set; }

    public string? Salon { get; set; }

    public DateTime? DiaAsignado { get; set; }

    public int Administrador { get; set; }

    public virtual Administrador AdministradorNavigation { get; set; } = null!;

    public virtual ICollection<Docente> Docentes { get; set; } = new List<Docente>();

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
