using System;
using System.Collections.Generic;

namespace ITC_Project_Manager.Models;

public partial class Tarjeta
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public byte[] Link { get; set; } = null!;

    public string Extension { get; set; } = null!;

    public DateTime FechaSubida { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
