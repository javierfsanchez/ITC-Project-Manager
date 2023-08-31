using System;
using System.Collections.Generic;

namespace ITC_Project_Manager.Models;

public partial class Proyecto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? NumIntegrantes { get; set; }

    public DateTime? UltActualizacion { get; set; }

    public string? Estado { get; set; }

    public int Tarjetas { get; set; }

    public int Presentación { get; set; }

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    public virtual ICollection<Observacion> Observacións { get; set; } = new List<Observacion>();

    public virtual Presentacion PresentaciónNavigation { get; set; } = null!;

    public virtual ICollection<Supervisor> Supervisors { get; set; } = new List<Supervisor>();

    public virtual Tarjeta TarjetasNavigation { get; set; } = null!;
}
