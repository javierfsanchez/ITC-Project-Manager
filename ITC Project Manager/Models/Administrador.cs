using System;
using System.Collections.Generic;

namespace ITC_Project_Manager.Models;

public partial class Administrador
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int? Telefono { get; set; }

    public int Usuario { get; set; }

    public virtual ICollection<Presentacion> Presentacións { get; set; } = new List<Presentacion>();

    public virtual Usuario UsuarioNavigation { get; set; } = null!;
}
