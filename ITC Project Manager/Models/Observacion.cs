using System;
using System.Collections.Generic;

namespace ITC_Project_Manager.Models;

public partial class Observacion
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? DiaRealizada { get; set; }

    public string? Tipo { get; set; }

    public int Proyecto { get; set; }

    public virtual Proyecto ProyectoNavigation { get; set; } = null!;
}
