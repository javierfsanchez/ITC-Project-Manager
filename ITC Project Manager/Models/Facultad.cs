using System;
using System.Collections.Generic;

namespace ITC_Project_Manager.Models;

public partial class Facultad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? TelefonoContacto { get; set; }

    public string Correo { get; set; } = null!;

    public virtual ICollection<Programa> Programas { get; set; } = new List<Programa>();
}
